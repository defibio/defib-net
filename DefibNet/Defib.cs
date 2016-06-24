using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace DefibNet
{
    class Defib
    {
        /// <summary>
        /// The defib key to send heartbeats to
        /// </summary>
        private string defibKey;

        public bool isMock;

        /// <summary>
        /// Creates a new defibrilator instance, which sends the heartbeats to the server
        /// </summary>
        /// <param name="key">The key provided by defib.io which allows you to send heartbeats</param>
        public Defib(string key, bool mock = false)
        {
            defibKey = key;
            isMock = mock;
        }

        /// <summary>
        /// Sends a heartbeat to Defib.IO
        /// </summary>
        public void sendHeartbeat()
        {
            if (isMock)
            {
                Reporter.reportBeat();
                return;
            }

            try {
                WebRequest httpRequest = WebRequest.Create("https://defib.io/heartbeat/receiver/" + defibKey);
                WebResponse httpResponse = httpRequest.GetResponse();

                Stream httpStream = httpResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(httpStream);
                string responseFromDefib = streamReader.ReadToEnd();

                if (responseFromDefib == @"{""status"":""success"",""msg"":""success""}")
                {
                    Reporter.reportBeat();
                }
                else
                {
                    Reporter.reportError();
                }

                streamReader.Close();
                httpStream.Close();
                httpResponse.Close();
            } catch (Exception e) {
                Reporter.reportException();
                Console.WriteLine(e.Message);
            }
        }
    }
}
