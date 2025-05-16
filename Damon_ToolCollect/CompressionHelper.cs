using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 压缩解压帮助类
    /// </summary>
    public class CompressionHelper
    {
        /// <summary>
        /// 使用Deflate压缩字节数组_(内存数据压缩)
        /// </summary>
        /// <param name="strHexData"></param>
        /// <returns></returns>
        public static string DeflateCompress(string strHexData)
        {
            try
            {
                byte[] data = HexHelper.HexStringToBytes(strHexData);
                using (var memoryStream = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(memoryStream, CompressionLevel.Optimal))
                    {
                        deflateStream.Write(data, 0, data.Length);
                    }
                    // 关闭 DeflateStream 后，MemoryStream 中的数据就是压缩后的数据
                    // 这里不需要调用 memoryStream.Close()，因为 using 会自动调用
                    // 直接返回 MemoryStream 的字节数组
                    // 注意：MemoryStream 的 Position 属性会在 using 语句结束时自动重置为 0
                    byte[] retBytes = memoryStream.ToArray();
                    return HexHelper.BytesToHexString(retBytes);
                }
            }
            catch (Exception ex)
            {
                throw new AggregateException("DeflateCompress=>" + ex.Message);
            }
        }

        /// <summary>
        /// 使用 Deflate 解压字节数组_(内存数据压缩)
        /// </summary>
        /// <param name="compressedHexData"></param>
        /// <returns></returns>
        public static string DeflateDecompress(string compressedHexData)
        {
            byte[] compressedData = HexHelper.HexStringToBytes(compressedHexData);
            using (var compressedStream = new MemoryStream(compressedData))
            using (var decompressedStream = new MemoryStream())
            using (var deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
            {
                deflateStream.CopyTo(decompressedStream);
                // 关闭 DeflateStream 后，MemoryStream 中的数据就是解压后的数据
                // 这里不需要调用 decompressedStream.Close()，因为 using 会自动调用
                // 直接返回 MemoryStream 的字节数组
                // 注意：MemoryStream 的 Position 属性会在 using 语句结束时自动重置为 0
                byte[] retBytes = decompressedStream.ToArray();
                return HexHelper.BytesToHexString(retBytes);
            }
        }

        /// <summary>
        /// 使用 GZip压缩数据_(文件存储、网络传输)
        /// </summary>
        public static string GZipCompress(string strData)
        {
            try
            {
                byte[] data = ConvertHelper.StringToByteArray(strData);
                using (var memoryStream = new MemoryStream())
                {
                    using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
                    {
                        gzipStream.Write(data, 0, data.Length);
                    }
                    // 关闭 GZipStream 后，MemoryStream 中的数据就是压缩后的数据
                    // 这里不需要调用 memoryStream.Close()，因为 using 会自动调用
                    // 直接返回 MemoryStream 的字节数组
                    // 注意：MemoryStream 的 Position 属性会在 using 语句结束时自动重置为 0
                    byte[] retBytes = memoryStream.ToArray();
                    return ConvertHelper.ByteArrayToString(retBytes);
                }
            }
            catch (Exception ex)
            {
                throw new AggregateException("GZipCompress=>"+ex.Message);
            }
        }
        /// <summary>
        /// 使用GZip解压数据_(文件存储、网络传输)
        /// </summary>
        public static string GZipDecompress(string strCompressedData)
        {
            try
            {
                byte[] compressedData = ConvertHelper.StringToByteArray(strCompressedData);
                using (var compressedStream = new MemoryStream(compressedData))
                using (var decompressedStream = new MemoryStream())
                using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    gzipStream.CopyTo(decompressedStream);
                    // 关闭 GZipStream 后，MemoryStream 中的数据就是解压后的数据
                    // 这里不需要调用 decompressedStream.Close()，因为 using 会自动调用
                    // 直接返回 MemoryStream 的字节数组
                    // 注意：MemoryStream 的 Position 属性会在 using 语句结束时自动重置为 0
                    byte[] retBtyes = decompressedStream.ToArray();
                    // 这里可以选择将字节数组转换为字符串
                    return ConvertHelper.ByteArrayToString(retBtyes);
                }
            }
            catch (Exception ex)
            {
                throw new AggregateException("GZipDecompress=>"+ex.Message);
            }
        }
        /// <summary>
        /// 压缩文件GZip_(大文件处理)
        /// </summary>
        /// <param name="sourceFile">需要压缩的文件名及路径</param>
        /// <param name="compressedFile">压缩后保存的文件名及路径(compressed.gz)</param>
        public static void CompressFile(string sourceFile, string compressedFile)
        {
            using (FileStream sourceStream = File.OpenRead(sourceFile))
            using (FileStream compressedStream = File.Create(compressedFile))
            using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionLevel.Optimal))
            {
                sourceStream.CopyTo(gzipStream);
            }
        }

        /// <summary>
        /// 解压文件GZip_(大文件处理)
        /// </summary>
        public static void DecompressFile(string compressedFile, string decompressedFile)
        {
            using (FileStream compressedStream = File.OpenRead(compressedFile))
            using (FileStream decompressedStream = File.Create(decompressedFile))
            using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            {
                gzipStream.CopyTo(decompressedStream);
            }
        }
    }
}
