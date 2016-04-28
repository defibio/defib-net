using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heartbeat;

namespace HeartbeatTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("hearbeats: 0");
            Console.WriteLine("exceptions: 0");
            Console.WriteLine("failed: 0");

            Heartbeat.Heartbeat heartbeat = new Heartbeat.Heartbeat("TEST", 30);

            while (true)
            {
                Console.SetCursorPosition(11, 0);
                Console.Write(Heartbeat.Reporter.beats);
                Console.SetCursorPosition(12, 1);
                Console.Write(Heartbeat.Reporter.exceptions);
                Console.SetCursorPosition(8, 2);
                Console.Write(Heartbeat.Reporter.errors);
            }
        }
    }
}
