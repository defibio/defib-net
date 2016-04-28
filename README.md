# Heartbeat.NET
A free C# library that allows you to send heartbeats to defib.io through any managed programming language such as C#, Visual Basic and F#.

## Get started
I have included a simple sample in the solution of this project, if you however can not be arsed to look that up here is a very simple example that will failures and successfull heartbeats in a console window.
```
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
```

## License
Heartbeat.NET is free to use under MIT, however defib.io may charge for some services, please look it up before using this library! I AM NOT RESPONSIBLE FOR ANY COSTS.
