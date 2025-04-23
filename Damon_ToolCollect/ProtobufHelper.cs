using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class ProtobufHelper
    {
        private const int MaxRecursionDepth = 64;
        private const int MaxHexDumpLength = 1024; // 最大十六进制输出长度

        /// <summary>
        /// 格式化protobuf数据
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static string ParseAndFormatProtobuf(string hexStr,bool isReduce = false)
        {
            byte[] bytes = HexHelper.HexStringToBytes(hexStr);
            if (isReduce)
            {
                var parsedData = ParseWithRetry(bytes, Parse);
                return FormatProtobuf(parsedData);
            }
            else
            {
                var parsedData = Parse(bytes);
                return FormatProtobuf(parsedData);
            }
            
        }
        /// <summary>
        /// 检查是否为protobuf数据
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static bool IsProtobuf(string hexStr)
        {
            byte[] bytes = HexHelper.HexStringToBytes(hexStr);
            try
            {
                Parse(bytes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T ParseWithRetry<T>(byte[] bytes, Func<byte[], T> parseFunc)
        {
            while (bytes.Length > 0)
            {
                try
                {
                    return parseFunc(bytes); // 尝试解析
                }
                catch (Exception) // 捕获解析异常
                {
                    if (bytes.Length == 0)
                        throw; // 如果已经没有字节可删，抛出异常

                    // 删除最后一个字节（复制前 n-1 个字节）
                    byte[] newBytes = new byte[bytes.Length - 1];
                    Array.Copy(bytes, 0, newBytes, 0, bytes.Length - 1);
                    bytes = newBytes;
                }
            }
            throw new InvalidOperationException("无法解析数据：所有字节已删除，但仍解析失败。");
        }
        /// <summary>
        /// 解析入口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static Dictionary<int, object> Parse(byte[] data)
        {
            using var stream = new CodedInputStream(data);
            return ParseFields(stream, 0);
        }
        /// <summary>
        /// 解析字段
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="currentDepth"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        private static Dictionary<int, object> ParseFields(CodedInputStream stream, int currentDepth)
        {
            if (currentDepth > MaxRecursionDepth)
            {
                throw new InvalidOperationException("Exceeded maximum recursion depth");
            }
            var result = new Dictionary<int, object>();
            while (!stream.IsAtEnd)
            {
                var tag = stream.ReadTag();
                if (tag == 0) break;
                var fieldNumber = WireFormat.GetTagFieldNumber(tag);
                var wireType = WireFormat.GetTagWireType(tag);
                object value = wireType switch
                {
                    WireFormat.WireType.Varint => stream.ReadInt64(),
                    WireFormat.WireType.Fixed64 => HandleDouble(stream),
                    WireFormat.WireType.LengthDelimited => HandleLengthDelimited(stream, currentDepth),
                    WireFormat.WireType.Fixed32 => HandleFloat(stream),
                    WireFormat.WireType.StartGroup => HandleGroup(stream, currentDepth),
                    _ => throw new InvalidDataException($"Unsupported wire type: {wireType}")
                };
                AddToDictionary(result, fieldNumber, value);
            }
            return result;
        }
        /// <summary>
        /// 处理双精度浮点数
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static string HandleDouble(CodedInputStream stream)
        {
            var bytes = BitConverter.GetBytes(stream.ReadDouble());
            return FormatHex(bytes, isFloat: false);
        }
        /// <summary>
        /// 处理浮点数
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static string HandleFloat(CodedInputStream stream)
        {
            var bytes = BitConverter.GetBytes(stream.ReadFloat());
            return FormatHex(bytes, isFloat: true);
        }
        /// <summary>
        /// 格式化十六进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isFloat"></param>
        /// <returns></returns>
        private static string FormatHex(byte[] bytes, bool isFloat)
        {
            Array.Reverse(bytes); // 转换为大端序
            var hex = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            return $"0x{hex}";
        }
        /// <summary>
        /// 处理长度限定的字段
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="currentDepth"></param>
        /// <returns></returns>
        private static object HandleLengthDelimited(CodedInputStream stream, int currentDepth)
        {
            var bytes = stream.ReadBytes();
            // 尝试解析为嵌套消息
            try
            {
                using var nestedStream = new CodedInputStream(bytes.ToByteArray());
                var nested = ParseFields(nestedStream, currentDepth + 1);
                if (nested.Count > 0) return nested;
            }
            catch { /* 不是嵌套消息 */ }

            // 尝试解码为字符串
            try
            {
                var str = bytes.ToStringUtf8();
                // 如果是有效的可打印字符串
                if (IsPrintableString(str)) return str;
            }
            catch { /* 不是有效UTF-8 */ }

            // 返回十六进制表示的字节
            return ConvertToHexString(bytes.ToByteArray());
        }

        private static bool IsPrintableString(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            return str.All(c => c >= 32 && c <= 126);
        }

        private static string ConvertToHexString(byte[] bytes)
        {
            var hex = BitConverter.ToString(bytes).Replace("-", "");
            return hex.Length > MaxHexDumpLength
                ? hex.Substring(0, MaxHexDumpLength) + "..."
                : hex;
        }
        /// <summary>
        /// 处理对象组
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="currentDepth"></param>
        /// <returns></returns>
        private static object HandleGroup(CodedInputStream stream, int currentDepth)
        {
            var groupData = new List<byte>();
            while (true)
            {
                var tag = stream.ReadTag();
                if (tag == 0) break;

                var wireType = WireFormat.GetTagWireType(tag);
                if (wireType == WireFormat.WireType.EndGroup)
                    break;
                // 将group数据转换为字节数组
                groupData.AddRange(BitConverter.GetBytes(tag));
                switch (wireType)
                {
                    case WireFormat.WireType.Varint:
                        groupData.AddRange(BitConverter.GetBytes(stream.ReadInt64()));
                        break;
                    case WireFormat.WireType.Fixed64:
                        groupData.AddRange(BitConverter.GetBytes(stream.ReadDouble()));
                        break;
                    case WireFormat.WireType.Fixed32:
                        groupData.AddRange(BitConverter.GetBytes(stream.ReadFloat()));
                        break;
                }
            }

            return ParseFields(new CodedInputStream(groupData.ToArray()), currentDepth + 1);
        }
        /// <summary>
        /// 添加到字典
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="fieldNumber"></param>
        /// <param name="value"></param>
        private static void AddToDictionary(IDictionary<int, object> dict, int fieldNumber, object value)
        {
            if (dict.TryGetValue(fieldNumber, out var existing))
            {
                switch (existing)
                {
                    case List<object> list:
                        list.Add(value);
                        break;
                    default:
                        dict[fieldNumber] = new List<object> { existing, value };
                        break;
                }
            }
            else
            {
                dict[fieldNumber] = value;
            }
        }

        private static string FormatProtobuf(Dictionary<int, object> data)
        {
            var sb = new StringBuilder();
            FormatProtobufInternal(data, sb, 0);
            return sb.ToString();
        }
        /// <summary>
        /// 输出制定格式
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sb"></param>
        /// <param name="indentLevel"></param>
        private static void FormatProtobufInternal(Dictionary<int, object> data,StringBuilder sb,int indentLevel)
        {
            var indent = new string(' ', indentLevel * 2);
            var fields = data.OrderBy(kv => kv.Key).ToList();
            for (int i = 0; i < fields.Count; i++)
            {
                var kv = fields[i];
                sb.Append(indent);
                sb.Append($"{kv.Key}: ");
                switch (kv.Value)
                {
                    case Dictionary<int, object> nested:
                        sb.AppendLine("{");
                        FormatProtobufInternal(nested, sb, indentLevel + 1);
                        sb.Append(indent).AppendLine("}");
                        break;

                    case List<object> list:
                        if (list.All(x => x is long || x is int))
                            sb.AppendLine($"[{string.Join(",", list)}]");
                        else if (list.All(x => x is string))
                            sb.AppendLine($"[{string.Join(",", list.Select(x => $"\"{x}\""))}]");
                        else
                            HandleMixedList(sb, list, indent);
                        break;

                    case string str when str.StartsWith("0x"):
                        sb.AppendLine(str); // 十六进制不带引号
                        break;

                    case string str:
                        sb.AppendLine($"\"{str}\"");
                        break;

                    case byte[] bytes:
                        sb.AppendLine($"\"{ConvertToHexString(bytes)}\"");
                        break;

                    default:
                        sb.AppendLine(kv.Value.ToString());
                        break;
                }
            }
        }
        /// <summary>
        /// 处理混合列表
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="list"></param>
        /// <param name="indent"></param>
        private static void HandleMixedList(StringBuilder sb, List<object> list, string indent)
        {
            sb.AppendLine();
            foreach (var item in list)
            {
                sb.Append(indent + "  ");
                switch (item)
                {
                    case Dictionary<int, object> nested:
                        sb.AppendLine("{");
                        FormatProtobufInternal(nested, sb, indent.Length / 2 + 1);
                        sb.Append(indent + "  ").AppendLine("}");
                        break;
                    case string str:
                        sb.AppendLine($"\"{str}\"");
                        break;
                    default:
                        sb.AppendLine(item.ToString());
                        break;
                }
            }
        }
    }
}
