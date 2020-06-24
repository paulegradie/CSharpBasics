using System;
using System.Net;

namespace OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new OddGenerator();
            foreach (var oddNumber in generator)
            {
                Console.WriteLine(oddNumber);
                if (oddNumber > 100) break;
            }

            Console.Read();
        }
    }
}