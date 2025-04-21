using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class WinRAR_1f_DataHelper
    {

        /// <summary>
        /// 检查数据是否为1f格式
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static bool Is1fData(string hexStr)
        {
            try
            {
                if (string.IsNullOrEmpty(hexStr))
                {
                    return false;
                }
                byte[] data = HexHelper.HexStringToBytes(hexStr);
                return data.Length > 2 && data[0] == 0x1F && data[1] == 0x8B;
            }
            catch (Exception ex)
            {
                throw new Exception("Is1fData=>" + ex.Message);
            }
        }

        /// <summary>
        /// 动态解压1f数据为原始字节数组
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static string Decomress1f(string hexStr)
        {
            try
            {
                byte[] retBytes = DecompressRawFrom1f(HexHelper.HexStringToBytes(hexStr));
                return HexHelper.BytesToHexString(retBytes);
            }
            catch (Exception ex) { throw new Exception("Decomress1f=>" + ex.Message); }
        }
        /// <summary>
        /// 动态压缩为1f格式
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static string Compress1f(string hexStr)
        {
            try
            {
                byte[] retBytes = CompressGzip(HexHelper.HexStringToBytes(hexStr));
                return HexHelper.BytesToHexString(retBytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Compress1f=>" + ex.Message);
            }
        }
        /// <summary>
        /// grpc 1f数据解压
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static string UnPackGrpc1f(string hexStr)
        {
            try
            {
                byte[] byteArray = HexHelper.HexStringToBytes(hexStr);
                if (byteArray == null || byteArray.Length == 0) throw new ArgumentException("Input data is null or empty.");
                if (byteArray[0] == 0x1f && byteArray[1] == 0x8b)
                {
                    byte[] retBytes = DecompressRawFrom1f(byteArray);
                    return HexHelper.BytesToHexString(retBytes);
                }
                using (var stream = new MemoryStream(byteArray))
                {
                    // Read the flag (1 byte)
                    int flag = stream.ReadByte();
                    // Read the length (4 bytes, big-endian)
                    byte[] lengthBytes = new byte[4];
                    stream.Read(lengthBytes, 0, 4);
                    int length = BitConverter.ToInt32(lengthBytes.Reverse().ToArray(), 0);
                    if (length <= 0 || length > stream.Length - stream.Position)
                        throw new InvalidOperationException("Invalid gRPC packet length.");
                    // Read the payload (excluding ignored bytes)
                    byte[] payload = new byte[length];
                    stream.Read(payload, 0, length);
                    byte[] retBytes = flag == 0x01 ? DecompressRawFrom1f(payload) : payload;
                    return HexHelper.BytesToHexString(retBytes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("UnPackGrpc1f=>" + ex.Message);
            }
        }
        /// <summary>
        /// 压缩为grpc 1f格式
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string PackGrpc1f(string hexStr)
        {
            try
            {
                byte[] byteArray = HexHelper.HexStringToBytes(hexStr);
                if (byteArray == null)
                {
                    throw new ArgumentException("Message cannot be null.");
                }
                byte[] compressedMessage = CompressGzip(byteArray);
                var messageLength = BitConverter.GetBytes((short)compressedMessage.Length);
                byte[] head = new byte[] { 0x01, 0x0, 0x0 };
                var retBytes = ByteHelper.AddBytes(head, messageLength.Reverse().ToArray(), compressedMessage);
                return HexHelper.BytesToHexString(retBytes);
            }
            catch (Exception ex)
            {
                throw new Exception("PackGrpc1f=>" + ex.Message);
            }
        }


        /// <summary>
        /// 动态解压1f数据为原始字节数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private static byte[] DecompressRawFrom1f(byte[] gzipData)
        {

            if (gzipData == null || gzipData.Length < 2)
            {
                throw new ArgumentException("Invalid GZIP data.");
            }
            // 检查GZIP标头（十六进制1F8B）
            if (gzipData[0] != 0x1F || gzipData[1] != 0x8B)
            {
                throw new InvalidOperationException("Data does not have a valid GZIP header.");
            }
            using (var inputStream = new MemoryStream(gzipData))
            using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (var outputStream = new MemoryStream())
            {
                gzipStream.CopyTo(outputStream);
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// 动态压缩为1f格式
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static byte[] CompressGzip(byte[] inputData)
        {
            try
            {
                if (inputData == null || inputData.Length == 0)
                {
                    throw new ArgumentException("Input data is null or empty.");
                }

                using (var outputStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        gzipStream.Write(inputData, 0, inputData.Length);
                    }
                    var ret = outputStream.ToArray();
                    //ret[8] = 0;//手动处理
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CompressGzip=>" + ex.Message);
            }
        }
    }
}
