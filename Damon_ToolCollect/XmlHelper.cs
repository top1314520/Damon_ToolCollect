using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Damon_ToolCollect
{
    public class XmlHelper
    {
        /// <summary>
        /// 格式化带有命名空间的XML字符串
        /// </summary>
        /// <param name="xmlString">XML字符串</param>
        /// <param name="indentChars">缩进字符（默认两个空格）</param>
        /// <returns>格式化后的XML字符串</returns>
        public static string FormatNamespacedXml(string xmlString, string indentChars = "  ")
        {
            if (string.IsNullOrWhiteSpace(xmlString))
                return xmlString;

            try
            {
                // 使用XDocument处理命名空间
                var doc = XDocument.Parse(xmlString);
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = indentChars,
                    Encoding = Encoding.UTF8,
                    OmitXmlDeclaration = !ContainsXmlDeclaration(xmlString)
                };

                // 处理命名空间缩进
                var stringBuilder = new StringBuilder();
                using (var writer = XmlWriter.Create(stringBuilder, settings))
                {
                    doc.Save(writer);
                }

                // 优化命名空间属性的换行
                return OptimizeNamespaceAttributes(stringBuilder.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"XML格式化错误: {ex.Message}");
                return xmlString;
            }
        }

        /// <summary>
        /// 优化命名空间属性的显示（将多个命名空间属性放在同一行）
        /// </summary>
        private static string OptimizeNamespaceAttributes(string xml)
        {
            var lines = xml.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var result = new StringBuilder();
            bool inRootElement = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                // 检测根元素开始
                if (line.StartsWith("<") && !line.StartsWith("</") && !inRootElement)
                {
                    inRootElement = true;
                    result.AppendLine(lines[i]);

                    // 收集命名空间属性行
                    var nsAttributes = new StringBuilder();
                    for (int j = i + 1; j < lines.Length; j++)
                    {
                        string nsLine = lines[j].Trim();
                        if (nsLine.StartsWith("xmlns:") || nsLine.StartsWith("xmlns="))
                        {
                            nsAttributes.Append(" " + nsLine.Trim());
                        }
                        else if (nsLine.EndsWith(">"))
                        {
                            // 合并命名空间属性到根元素
                            string rootLine = lines[i].TrimEnd('>') + nsAttributes.ToString() + ">";
                            result.Replace(lines[i], rootLine);
                            i = j - 1; // 跳过已处理的行
                            break;
                        }
                    }
                }
                else if (!line.StartsWith("xmlns:") && !line.StartsWith("xmlns="))
                {
                    // 非命名空间属性行正常添加
                    result.AppendLine(lines[i]);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// 检查字符串是否包含XML声明
        /// </summary>
        private static bool ContainsXmlDeclaration(string xmlString)
        {
            return xmlString.TrimStart().StartsWith("<?xml", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 比较两个XML字符串是否在结构上相等（忽略格式和空白）
        /// </summary>
        public static bool AreXmlEqual(string xml1, string xml2)
        {
            try
            {
                var doc1 = XDocument.Parse(xml1);
                var doc2 = XDocument.Parse(xml2);
                return XNode.DeepEquals(doc1, doc2);
            }
            catch
            {
                return false;
            }
        }
        

        #region 压缩成base64和解压
        /// <summary>
        /// 压缩XML字符串
        /// </summary>
        /// <param name="xmlString">要压缩的XML字符串</param>
        /// <param name="compressionMethod">压缩方法（GZip或Deflate）</param>
        /// <returns>Base64编码的压缩结果</returns>
        public static string CompressXml(string xmlString, CompressionMethod compressionMethod = CompressionMethod.GZip)
        {
            if (string.IsNullOrEmpty(xmlString))
                throw new ArgumentNullException(nameof(xmlString));

            byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
            byte[] compressedBytes;

            using (var outputStream = new MemoryStream())
            {
                Stream compressionStream = compressionMethod == CompressionMethod.GZip
                    ? new GZipStream(outputStream, CompressionMode.Compress)
                    : (Stream)new DeflateStream(outputStream, CompressionMode.Compress);

                using (compressionStream)
                {
                    compressionStream.Write(xmlBytes, 0, xmlBytes.Length);
                }

                compressedBytes = outputStream.ToArray();
            }

            return Convert.ToBase64String(compressedBytes);
        }

        /// <summary>
        /// 解压XML字符串
        /// </summary>
        /// <param name="compressedXml">Base64编码的压缩XML</param>
        /// <param name="compressionMethod">压缩方法（GZip或Deflate）</param>
        /// <returns>解压后的XML字符串</returns>
        public static string DecompressXml(string compressedXml, CompressionMethod compressionMethod = CompressionMethod.GZip)
        {
            if (string.IsNullOrEmpty(compressedXml))
                throw new ArgumentNullException(nameof(compressedXml));

            byte[] compressedBytes = Convert.FromBase64String(compressedXml);

            using (var inputStream = new MemoryStream(compressedBytes))
            {
                Stream decompressionStream = compressionMethod == CompressionMethod.GZip
                    ? new GZipStream(inputStream, CompressionMode.Decompress)
                    : (Stream)new DeflateStream(inputStream, CompressionMode.Decompress);

                using (var outputStream = new MemoryStream())
                using (decompressionStream)
                {
                    decompressionStream.CopyTo(outputStream);
                    return Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }
        }

        /// <summary>
        /// 压缩XmlDocument对象
        /// </summary>
        public static string CompressXmlDocument(XmlDocument xmlDoc, CompressionMethod compressionMethod = CompressionMethod.GZip)
        {
            if (xmlDoc == null)
                throw new ArgumentNullException(nameof(xmlDoc));

            using (var writer = new StringWriter())
            {
                xmlDoc.Save(writer);
                return CompressXml(writer.ToString(), compressionMethod);
            }
        }

        /// <summary>
        /// 解压为XmlDocument对象
        /// </summary>
        public static XmlDocument DecompressToXmlDocument(string compressedXml, CompressionMethod compressionMethod = CompressionMethod.GZip)
        {
            string xmlString = DecompressXml(compressedXml, compressionMethod);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            return xmlDoc;
        }

        /// <summary>
        /// 压缩XML文件
        /// </summary>
        public static void CompressXmlFile(string sourceFilePath, string compressedFilePath, CompressionMethod compressionMethod = CompressionMethod.GZip)
        {
            if (!File.Exists(sourceFilePath))
                throw new FileNotFoundException("Source XML file not found", sourceFilePath);

            string xmlContent = File.ReadAllText(sourceFilePath);
            string compressedXml = CompressXml(xmlContent, compressionMethod);
            File.WriteAllText(compressedFilePath, compressedXml);
        }

        /// <summary>
        /// 解压XML文件
        /// </summary>
        public static void DecompressXmlFile(string compressedFilePath, string outputFilePath, CompressionMethod compressionMethod = CompressionMethod.GZip)
        {
            if (!File.Exists(compressedFilePath))
                throw new FileNotFoundException("Compressed XML file not found", compressedFilePath);

            string compressedXml = File.ReadAllText(compressedFilePath);
            string xmlContent = DecompressXml(compressedXml, compressionMethod);
            File.WriteAllText(outputFilePath, xmlContent);
        } 
        #endregion

    }
    public enum CompressionMethod
    {
        GZip,
        Deflate
    }
}
