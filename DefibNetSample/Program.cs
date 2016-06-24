using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefibNet;

namespace DefibNetSample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("hearbeats: 0");
            Console.WriteLine("exceptions: 0");
            Console.WriteLine("failed: 0");

            Heartbeat heartbeat = new Heartbeat("TEST", 1);

            while (true)
            {
                Console.SetCursorPosition(11, 0);
                Console.Write(Reporter.beats);
                Console.SetCursorPosition(12, 1);
                Console.Write(Reporter.exceptions);
                Console.SetCursorPosition(8, 2);
                Console.Write(Reporter.errors);
            }
        }
    }
}
