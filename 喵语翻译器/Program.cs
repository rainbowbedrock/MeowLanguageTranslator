using System;
using 喵语翻译器;

namespace 喵语翻译器Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2) Help();
            else if (args[0] == "-e"|| args[0] == "-encode") Encode(args[1]);
            else if(args[0]=="-d"|| args[0] == "-decode") Decode(args[1]);
#if DEBUG
            Main(Console.ReadLine().Split(' '));
#endif
        }
        static void Help()
        {
            Console.WriteLine("喵语翻译器V0.1");
            Console.WriteLine("-e [待编码字符]");
            Console.WriteLine("-d [待解码字符]");
        }
        static void Encode(string str)
        {
            Console.WriteLine(喵.喵喵Encode(str));
        }
        static void Decode(string str)
        {
            try
            {
                Console.WriteLine(喵.喵喵Decode(str));
            }
            catch (Exception ex)
            {
                Console.WriteLine("解码失败！");
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
