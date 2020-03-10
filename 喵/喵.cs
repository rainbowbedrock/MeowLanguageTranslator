using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace 喵语翻译器
{
    public static class 喵
    {
        public static string 喵喵Encode(string cat)
        {

            var 喵喵们 = Encoding.Unicode.GetBytes(cat);
            bool 压缩喵喵 = 喵喵们.Length > 100;
            if (压缩喵喵)
                喵喵们 = 喵变小(喵喵们);
            
            string 喵 = "";
            foreach (byte 一只喵 in 喵喵们)
                喵 += Convert.ToString(一只喵, 2).PadLeft(8, '0');
            string 喵喵 = 变成喵(喵);
            if (压缩喵喵)
                return "喵！" + 喵喵;
            else return "喵？" + 喵喵;
        }
        public static string 喵喵Decode(string cat)
        {
            string 喵 = "", 小喵 = "";
            if (!(cat.StartsWith("喵！") || cat.StartsWith("喵？")))
                throw new Exception();
            bool 压缩喵喵 = cat.StartsWith("喵！");
            cat = cat.Substring(2);
            foreach(char 一只喵 in cat)
            {
                小喵 += 一只喵;
                if (一只喵 == '！'|| 一只喵 == '？'|| 一只喵 == '～'|| 一只喵=='。') { 喵 += 喵喵表.Forward[小喵]; 小喵 = ""; }
            }
            return 喵喵喵(喵, 压缩喵喵);
        }
        internal static string 喵喵喵(string cat,bool 压缩喵喵)
        {
            cat = cat.PadLeft(8 * (int)Math.Ceiling((double)cat.Length / 8), '0');
            List<byte> 所有的喵喵 = new List<byte>();
            for(int 喵喵的位置=0; 喵喵的位置<cat.Length; 喵喵的位置 += 8)
            {
                所有的喵喵.Add(Convert.ToByte(cat.Substring(喵喵的位置, 8), 2));
            }
            byte[] 最后的喵;
            if (压缩喵喵)
                最后的喵 = 喵变大(所有的喵喵.ToArray());
            else 最后的喵 = 所有的喵喵.ToArray();
            return Encoding.Unicode.GetString(最后的喵);
        }
        internal static string 变成喵(string cat)
        {
            string 喵 = "";
            for (int 喵喵的位置 = 0; 喵喵的位置 < cat.Length; 喵喵的位置 += 4)
            {
                喵 += 喵喵表.Reverse[cat.Substring(喵喵的位置, 4)];
                
            }
            return 喵;
            
        }
        public static byte[] 喵变小(byte[] cat)
        {
            try
            {
                MemoryStream 喵喵流 = new MemoryStream();
                GZipStream 喵 = new GZipStream(喵喵流, CompressionMode.Compress, true);
                喵.Write(cat, 0, cat.Length);
                喵.Close();
                byte[] 喵喵 = new byte[喵喵流.Length];
                喵喵流.Position = 0;
                喵喵流.Read(喵喵, 0, 喵喵.Length);
                喵喵流.Close();
                return 喵喵;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static byte[] 喵变大(byte[] cat)
        {
            try
            {
                MemoryStream 喵 = new MemoryStream(cat);
                GZipStream 压缩喵喵 = new GZipStream(喵, CompressionMode.Decompress, true);
                MemoryStream 喵喵流 = new MemoryStream();
                byte[] 喵喵 = new byte[0x1000];
                while (true)
                {
                    int reader = 压缩喵喵.Read(喵喵, 0, 喵喵.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    喵喵流.Write(喵喵, 0, reader);
                }
                压缩喵喵.Close();
                喵.Close();
                喵喵流.Position = 0;
                喵喵 = 喵喵流.ToArray();
                喵喵流.Close();
                return 喵喵;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        internal static Map<string, string> 喵喵表 = new Map<string, string>()
        {
            {"喵喵喵喵！","0000" },
            {"喵喵喵喵？","0001" },
            {"喵喵喵喵～","0010" },
            {"喵喵喵喵。","0011" },
            {"喵喵喵？","0100" },
            {"喵喵喵～","0101" },
            {"喵喵喵！","0110" },
            {"喵喵喵。","0111" },
            {"喵喵！","1000" },
            {"喵喵？","1001" },
            {"喵喵～","1010" },
            {"喵喵。","1011" },
            {"喵？","1100" },
            {"喵～","1101" },
            {"喵！","1110" },
            {"喵。","1111" },
        };
        
    }

}
