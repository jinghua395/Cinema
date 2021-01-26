using System;
using System.Threading.Tasks;

namespace Cinema
{
    public static class Printer
    {
        public static Task Print(string str = "")
        {
            Console.Write(str);
            return Task.CompletedTask;
        }

        public static Task PrintLine(string str = "")
        {
            Console.WriteLine(str);
            return Task.CompletedTask;
        }

        public static Task PrintError(string str = "")
        {
            Console.WriteLine(str);
            return Task.CompletedTask;
        }

        public static Task<string> Read()
        {
            var s = Console.ReadLine();
            return Task.FromResult(s);
        }
    }
}
