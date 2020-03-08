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

            var 喵喵们 = Encoding.UTF8.GetBytes(cat);
            string 喵 = "";
            foreach (byte 一只喵 in 喵喵们)
                喵 += Convert.ToString(一只喵, 2).PadLeft(8, '0');
            if (喵.Length % 3 == 1) 喵 = "00" + 喵;
            else if (喵.Length % 3 == 2) 喵 = "0" + 喵;
            return 变成喵(喵);
        }
        public static string 喵喵Decode(string cat)
        {
            string 喵 = "", 小喵 = "";
            foreach(char 一只喵 in cat)
            {
                小喵 += 一只喵;
                if (一只喵 == '！'|| 一只喵 == '？'|| 一只喵 == '～') { 喵 += 喵喵表[小喵]; 小喵 = ""; }
            }
            喵 = 喵.TrimStart('0');
            return 喵喵喵(喵);
        }
        public static string 喵喵喵(string cat)
        {
            cat = cat.PadLeft(8 * (int)Math.Ceiling((double)cat.Length / 8), '0');
            List<byte> 所有的喵喵 = new List<byte>();
            for(int 喵喵的位置=0; 喵喵的位置<cat.Length; 喵喵的位置 += 8)
            {
                所有的喵喵.Add(Convert.ToByte(cat.Substring(喵喵的位置, 8), 2));
            }
            return Encoding.UTF8.GetString(所有的喵喵.ToArray());
        }
        public static string 变成喵(string cat)
        {
            string 喵 = "";
            for (int 喵喵的位置 = 0; 喵喵的位置 < cat.Length; 喵喵的位置 += 3)
            {
                喵 += 喵喵表[cat.Substring(喵喵的位置, 3)];
                
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
        internal static Dictionary<string, string> 喵喵表 = new Dictionary<string, string>()
        {
            {"喵！","000" },
            {"喵？","001" },
            {"喵～","010" },
            {"喵喵！","011" },
            {"喵喵？","100" },
            {"喵喵～","101" },
            {"喵喵喵～","110" },
            {"喵喵喵！","111" },
            {"000","喵！" },
            {"001","喵？" },
            {"010","喵～" },
            {"011","喵喵！" },
            {"100","喵喵？" },
            {"101","喵喵～" },
            {"110","喵喵喵～" },
            {"111","喵喵喵！" }
        };

        
    }

}
