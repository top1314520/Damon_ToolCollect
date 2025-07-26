using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Damon_ToolCollect
{
    public class WinRAR_789_DataHelper
    {
        /// <summary>
        /// 压缩成789数据
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        /// <exception cref="AggregateException"></exception>
        public static string compress(string strSource)
        {
            byte[] bytes = HexHelper.HexStringToBytes(strSource);
            MemoryStream outms = new MemoryStream();
            MemoryStream inms = new MemoryStream(bytes);
            ComponentAce.Compression.Libs.zlib.ZOutputStream outZStream = new ComponentAce.Compression.Libs.zlib.ZOutputStream(outms, ComponentAce.Compression.Libs.zlib.zlibConst.Z_DEFAULT_COMPRESSION);
            try
            {
                CopyStream(inms, outZStream);
            }
            catch (Exception ex)
            {
                throw new AggregateException("compress=>"+ex.Message);
            }
            finally
            {
                outZStream.Close();
            }
            byte[] rs = outms.ToArray();
            return HexHelper.BytesToHexString(rs);
        }
        /// <summary>
        /// 解压789数据
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        /// <exception cref="AggregateException"></exception>
        public static string decompress(string strSource)
        {
            int data = 0;
            int stopByte = -1;
            try
            {
                byte[] Buffer = HexHelper.HexStringToBytes(strSource);
                MemoryStream intms = new MemoryStream(Buffer);
                MemoryStream outms = new MemoryStream();
                ComponentAce.Compression.Libs.zlib.ZInputStream inZStream = new ComponentAce.Compression.Libs.zlib.ZInputStream(intms);
                int count = strSource.Length;
                byte[] inByteList = new byte[count * 10];
                int i = 0;
                while (stopByte != (data = inZStream.Read()))
                {
                    inByteList[i] = (byte)data;
                    i++;
                }
                inZStream.Close();
                return HexHelper.BytesToHexString(inByteList, i);
            }
            catch (Exception ex)
            {
                throw new AggregateException("decompress=>" + ex.Message);
            }

        }
        private static void CopyStream(System.IO.Stream input, System.IO.Stream output)
        {
            byte[] buffer = new byte[2000];
            int len;
            while ((len = input.Read(buffer, 0, 2000)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }
    }
}
