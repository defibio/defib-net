using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefibNet
{
    public static class Reporter
    {
        /// <summary>
        /// The amount of beats sent to Defib.IO that were successfully received.
        /// </summary>
        public static int beats
        {
            get; set;
        }


        /// <summary>
        /// The amount of beats sent to Defib.IO that were not successfully received.
        /// </summary>
        public static int errors
        {
            get; set;
        }

        /// <summary>
        /// Occured exceptions, however not those that occured while sending a request to Defib.IO
        /// </summary>
        public static int exceptions
        {
            get; set;
        }

        /// <summary>
        /// Initializes the heartbeat reporter
        /// </summary>
        public static void initialize()
        {
            beats = 0;
            exceptions = 0;
            errors = 0;
        }

        /// <summary>
        /// Reports a successfull Defib.IO request.
        /// </summary>
        public static void reportBeat()
        {
            beats++;
        }

        /// <summary>
        /// Reports a failed Defib.IO request.
        /// </summary>
        public static void reportError()
        {
            errors++;
        }

        /// <summary>
        /// Reports a exception
        /// </summary>
        public static void reportException()
        {
            exceptions++;
        }
    }
}
