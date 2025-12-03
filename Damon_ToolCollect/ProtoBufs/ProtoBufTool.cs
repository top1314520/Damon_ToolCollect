using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect.ProtoBufs
{
    public class ProtoBufTool
    {
        /// <summary>
        /// 将Protobuf消息对象序列化为字节数组
        /// </summary>
        /// <typeparam name="T">Protobuf消息类型</typeparam>
        /// <param name="message">要序列化的消息对象</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] pbSerialize<T>(T message) where T : IMessage<T>
        {
            if (message == null)
            {
                throw new ArgumentNullException("pbSerialize=>" + nameof(message));
            }
            try
            {
                using (var stream = new MemoryStream())
                {
                    message.WriteTo(stream);
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pbSerialize=>"+ex.Message);
            }
        }
        /// <summary>
        /// 将字节数组反序列化为 Protobuf 消息对象
        /// </summary>
        /// <typeparam name="T">Protobuf 消息类型</typeparam>
        /// <param name="data">包含序列化数据的字节数组</param>
        /// <param name="message">用于接收反序列化数据的消息对象</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void pbDeserialize<T>(byte[] data, T message) where T : IMessage<T>
        {
            if (data == null)
            {
                throw new ArgumentNullException("pbDeserialize=>" + nameof(data));
            }
            if (message == null)
            {
                throw new ArgumentNullException("pbDeserialize=>" + nameof(message));
            }
            try
            {
                message.MergeFrom(data);
            }
            catch (Exception ex)
            {
                throw new Exception("pbDeserialize=>" + ex.Message);
            }
        }

        /// <summary>
        /// 将 Protobuf 消息对象序列化为 Base64 字符串
        /// </summary>
        /// <typeparam name="T">Protobuf 消息类型</typeparam>
        /// <param name="message">要序列化的消息对象</param>
        /// <returns>Base64 编码的字符串</returns>
        public static string pbSerializeToBase64<T>(T message) where T : IMessage<T>
        {
            if (message == null)
            {
                throw new ArgumentNullException("pbSerializeToBase64=>" + nameof(message));
            }
            var bytes = pbSerialize(message);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// 将 Base64 字符串反序列化为 Protobuf 消息对象
        /// </summary>
        /// <typeparam name="T">Protobuf 消息类型</typeparam>
        /// <param name="base64String">Base64 编码的字符串</param>
        /// <param name="message">用于接收反序列化数据的消息对象</param>
        public static void pbDeserializeFromBase64<T>(string base64String, T message) where T : IMessage<T>
        {
            if (string.IsNullOrEmpty(base64String))
            {
                throw new ArgumentNullException("pbDeserializeFromBase64=>" + nameof(base64String));
            }
            var bytes = Convert.FromBase64String(base64String);
            pbDeserialize(bytes, message);
        }
        /// <summary>
        /// 将 Protobuf 消息对象序列化并写入文件
        /// </summary>
        /// <typeparam name="T">Protobuf 消息类型</typeparam>
        /// <param name="message">要序列化的消息对象</param>
        /// <param name="filePath">文件路径</param>
        public static void pbSerializeToFile<T>(T message, string filePath) where T : IMessage<T>
        {
            if (message == null)
            {
                throw new ArgumentNullException("pbSerializeToFile=>" + nameof(message));
            }
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("pbSerializeToFile=>" + nameof(filePath));
            }
            try
            {
                using (var fileStream = File.Create(filePath))
                {
                    message.WriteTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pbSerializeToFile=>" + ex.Message);
            }
        }
    }
}
