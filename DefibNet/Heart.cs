using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefibNet
{
    class Heart
    {
        /// <summary>
        /// The defribilator, which sends heartbeats to Defib.IO
        /// </summary>
        private Defib defib
        {
            get; set;
        }

        /// <summary>
        /// The timer that will trigger the heartbeats
        /// </summary>
        private Timer timer
        {
            get; set;
        }

        /// <summary>
        /// Creates a new heart that will start beating during the interval
        /// </summary>
        /// <param name="key">The Defib.IO key</param>
        /// <param name="interval">The interval at which to start beating</param>
        public Heart(string key, int interval, bool mock = false)
        {
            // 06-24-2016: Kinda weird that we only support heartbeats in minutes on defib.io but this one is in seconds, so just put a wrapper on it and we're good to go.
            interval = interval * 60;

            defib = new Defib(key, mock);
            timer = new Timer(beat, "Heartbeat", TimeSpan.FromSeconds(interval), TimeSpan.FromSeconds(interval)); 
        }

        /// <summary>
        /// Sends a heartbeat to Defib.IO
        /// </summary>
        /// <param name="state">Timer state</param>
        private void beat(object state)
        {
            defib.sendHeartbeat();
        }
    }
}
