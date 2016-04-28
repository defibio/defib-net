using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heartbeat
{
    public class Heartbeat
    {
        /// <summary>
        /// The key provided by defib.io which allows you to send heartbeats
        /// </summary>
        public string key
        {
            get; set;
        }

        /// <summary>
        /// How often a heartbeat should be sent to defib.io in seconds
        /// </summary>
        public int interval
        {
            get; set;
        }

        /// <summary>
        /// The heart that will send heatbeats to Defib.IO at the given intervals
        /// </summary>
        private Heart heart;

        /// <summary>
        /// Creates a new Heartbeat instance
        /// </summary>
        /// <param name="defibKey">The key provided by defib.io which allows you to send heartbeats</param>
        /// <param name="defibInterval">How often a heartbeat should be sent to defib.io in seconds</param>
        public Heartbeat(string defibKey, int defibInterval)
        {
            Reporter.initialize();
            heart = new Heart(defibKey, defibInterval);
        }
    }
}
