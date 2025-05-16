using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport.Client;

namespace Damon_ToolCollect
{
    public class ThriftHelper
    {
        /// <summary>
        /// 解析十六进制字符串表示的Thrift数据
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        /// <exception cref="AggregateException"></exception>
        private static string retThriftResult(string jsonStr)
        {
            try
            {
                byte[] thriftData = HexHelper.HexStringToBytes(jsonStr);
                // 1. 将十六进制字符串转换为字节数组
                if (thriftData == null || thriftData.Length == 0)
                {
                    throw new ArgumentException("Thrift data cannot be null or empty");
                }
                // 1. 创建 MemoryStream 包装 byte[]
                var stream = new MemoryStream(thriftData);
                // 2. 创建 Thrift 传输层对象
                var transport = new TStreamTransport(stream, null,null);
                // 3. 创建协议层对象（这里使用紧凑协议）
                TProtocol protocol = new TCompactProtocol(transport);
                ThriftCompactProtocolParser thriftCompactProtocol =new ThriftCompactProtocolParser(protocol);
                var keyValuePairs = thriftCompactProtocol.DecodeAsync();
                #region 包头属性
                string methodName = thriftCompactProtocol._message.Name;
                string messageType = thriftCompactProtocol._message.Type.ToString();
                string sequenceId = thriftCompactProtocol._message.SeqID.ToString(); 
                #endregion
                return JsonConvert.SerializeObject(keyValuePairs);
            }
            catch (Exception ex)
            {
                throw new AggregateException("retThriftResult=>反序列化失败=>" + ex.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkgBufferHex"></param>
        /// <returns></returns>
        public static string ThriftUnPackToJson(string pkgBufferHex)
        {
            try
            {
                byte[] pkgBuffer = HexHelper.HexStringToBytes(pkgBufferHex);
                // 验证基本长度
                if (pkgBuffer == null || pkgBuffer.Length < 10)
                {
                    throw new ArgumentException("Package too short (min 10 bytes required)");
                }
                // 解析头部
                byte firstByte = pkgBuffer[0];
                byte secondByte = pkgBuffer[1];
                // 验证魔数 (130 = 0x82)
                if (firstByte != 0x82)
                {
                    throw new FormatException($"Invalid magic number: 0x{firstByte:X2}");
                }
                // 解析版本和消息类型
                int version = (secondByte & 0x1F);
                string messageType = GetMessageType((secondByte >> 5) & 0x07);
                // 解析变长整数 (序列号)
                int index = 2;
                ulong sequenceId = ReadVarInt(pkgBuffer, ref index);
                // 解析方法名
                ulong nameLength = ReadVarInt(pkgBuffer, ref index);
                if (nameLength > int.MaxValue)
                {
                    throw new FormatException($"Method name too long: {nameLength} bytes");
                }
                string methodName = Encoding.UTF8.GetString(pkgBuffer, index, (int)nameLength);
                index += (int)nameLength;
                // 剩余部分作为参数
                byte[] arguments = new byte[pkgBuffer.Length - index];
                Array.Copy(pkgBuffer, index, arguments, 0, arguments.Length);

                string retStrJson = retThriftResult(pkgBufferHex);
                object jsonObj = JsonConvert.DeserializeObject(retStrJson);
                // 构建结果对象
                string successResult = ThriftResult.retThriftResult(true, "", 0x82, version, messageType, (int)sequenceId, methodName, arguments, jsonObj);
                return successResult;
            }
            catch (Exception ex)
            {
                // 返回错误信息
                string errorResult = ThriftResult.retThriftResult(false, ex.Message, 0, 0, "", 0, "", Array.Empty<byte>(),null);
                return errorResult;
            }
        }
        private static string GetMessageType(int type)
        {
            return type switch
            {
                0x01 => "CALL",         //请求
                0x02 => "REPLY",        //响应
                0x03 => "EXCEPTION",    //异常
                0x04 => "ONEWAY",       //单向请求
                _ => $"UNKNOWN(0x{type:X2})"
            };
        }

        private static ulong ReadVarInt(byte[] buffer, ref int index)
        {
            ulong result = 0;
            int shift = 0;
            byte b;

            do
            {
                if (index >= buffer.Length)
                {
                    throw new IndexOutOfRangeException("Unexpected end of buffer while reading varint");
                }

                b = buffer[index++];
                result |= (ulong)(b & 0x7F) << shift;
                shift += 7;

                if (shift > 63)
                {
                    throw new FormatException("Varint too long (max 64 bits)");
                }
            }
            while ((b & 0x80) != 0);

            return result;
        }
    }

    //返回的对象结构
    public class ThriftResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string error { get; set; } = "";
        /// <summary>
        /// 头部信息
        /// </summary>
        public ThriftHeader? header { get; set; }
        /// <summary>
        /// 消息体
        /// </summary>
        public ThriftMessage? message { get; set; }
        /// <summary>
        /// 返回Thrift结果
        /// </summary>
        /// <param name="success">是否成功</param>
        /// <param name="error">如果错误，描述错误内容</param>
        /// <param name="protocolType">协议类型</param>
        /// <param name="protocolVersion">协议版本号</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="sequenceId">序列号，用于标识请求和响应的对应关系</param>
        /// <param name="methodName">方法名称，比如调用的RPC方法名</param>
        /// <param name="dataContent">参数内容，通常是一个字节数组，表示方法调用的参数或返回值</param>
        /// <returns></returns>
        public static string retThriftResult(bool success, string error,int protocolType,int protocolVersion,string messageType,int sequenceId,string methodName, byte[] dataContent, object jsonObj)
        {
            ThriftHeader? header = new ThriftHeader 
            {
                protocolType = protocolType,
                protocolVersion = protocolVersion,
                messageType = messageType
            };
            if (dataContent == null) 
            {
                dataContent = Array.Empty<byte>();
            }
            ThriftMessage? message = new ThriftMessage
            {
                sequenceId = sequenceId,
                methodName = methodName,
                dataContent = dataContent,
                dataContentObj = jsonObj
            };
            var result = new ThriftResult
            {
                success = success,
                error = error,
                header = header,
                message = message
            };
            return JsonConvert.SerializeObject(result);
        }
        /// <summary>
        /// 反序列化成对象
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        /// <exception cref="AggregateException"></exception>
        public static ThriftResult retThriftResult(string jsonStr)
        {
            try
            {
                ThriftResult? thriftResult = JsonConvert.DeserializeObject<ThriftResult>(jsonStr);
                if (thriftResult == null)
                {
                    throw new AggregateException("thriftResult=>反序列化失败!");
                }
                return thriftResult;
            }
            catch (Exception ex)
            {
                throw new AggregateException("retThriftResult=>反序列化失败=>"+ex.Message);
            }
        }
    }

    public class ThriftHeader
    {
        /// <summary>
        /// 表示协议格式，比如第一个字节0x82表示Thrift Compact Protocol协议
        /// </summary>
        public int protocolType { get; set; }
        /// <summary>
        /// 协议版本
        /// </summary>
        public int protocolVersion { get; set; }
        /// <summary>
        /// 消息类型，比如CALL表示请求，REPLY表示响应
        /// </summary>
        public string messageType { get; set; } = "";
    }

    public class ThriftMessage
    {
        /// <summary>
        /// 序列号，用于标识请求和响应的对应关系
        /// </summary>
        public long sequenceId { get; set; }
        /// <summary>
        /// 方法名称，比如调用的RPC方法名
        /// </summary>
        public string methodName { get; set; } = "";
        /// <summary>
        /// 参数内容，通常是一个字节数组，表示方法调用的参数或返回值
        /// </summary>
        public byte[]? dataContent { get; set; }
        /// <summary>
        /// 数据内容解析对象
        /// </summary>
        public object? dataContentObj { get; set; }
    }
}
