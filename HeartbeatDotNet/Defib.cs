using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Heartbeat
{
    class Defib
    {
        /// <summary>
        /// The request header that will be sent to Defib.IO
        /// </summary>
        private string requestHeader
        {
            get; set;
        }

        /// <summary>
        /// The socket used to connect to Defib.IO
        /// </summary>
        private Socket requestSocket
        {
            get; set;
        }

        /// <summary>
        /// Creates a new defibrilator instance, which sends the heartbeats to the server
        /// </summary>
        /// <param name="key">The key provided by defib.io which allows you to send heartbeats</param>
        public Defib(string key)
        {
            requestHeader = "GET /heartbeat/receive/{0} HTTP /1.1"
                + "\r\nHost: {1}"
                + "\r\nConnection: keep-alive"
                + "\r\nAccept: text/html"
                + "\r\nUser-Agent: Heartbeat.NET";

            requestHeader = string.Format(requestHeader, key, Dns.GetHostAddresses("defib.io")[0]);

            try
            {
                requestSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            } catch (Exception e) {
                Reporter.reportException();
            }
        }

        /// <summary>
        /// Sends a heartbeat to Defib.IO
        /// </summary>
        public void sendHeartbeat()
        {
            try
            {
                requestSocket.Connect(Dns.GetHostAddresses("defib.io")[0], 80);

                requestSocket.Send(Encoding.ASCII.GetBytes(requestHeader));

                bool reading = true;

                while (reading)
                {
                    byte[] buffer = new byte[16];
                    requestSocket.Receive(buffer);

                    string responseHeader = Encoding.ASCII.GetString(buffer);

                    Console.WriteLine(responseHeader);

                    if (responseHeader.Contains("{"))
                    {
                        if (responseHeader.Contains("error"))
                        {
                            Reporter.reportError();
                        } else if (responseHeader.Contains("404")) {
                            Reporter.reportError();
                        } else {
                            Reporter.reportBeat();
                        }
                        requestSocket.Close();
                        reading = false;
                    } else {
                        throw new Exception("Unexpected response.");
                    }
                }
            } catch (Exception e) {
                Reporter.reportException();
            }
        }
    }
}
