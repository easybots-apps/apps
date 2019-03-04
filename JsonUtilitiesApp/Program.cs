using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Easybots.Apps.EasybotsApp("JSON Utilities (GitHub)")]

namespace JsonUtilities
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var link = Easybots.Apps.EasybotsLink.CreateLink();
            JsonBot jsonBot = new JsonBot();
            Console.WriteLine("=============================");
            Console.WriteLine("JSON Utilities Easybots App...");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine("Pressing ENTER will close this app.");
            Console.ReadLine();
        }
    }
}
