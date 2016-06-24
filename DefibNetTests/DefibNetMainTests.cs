using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefibNet;

namespace DefibNetTests
{
    [TestFixture]
    public class DefibNetMainTests
    {
        [Test]
        public static void TestHeartbeatSuccessfull()
        {
            Heartbeat heartbeat = new Heartbeat("TESTKEY", 1, true);

            System.Threading.Thread.Sleep(61 * 1000);

            Assert.AreEqual(Reporter.beats, 1);
        }

        [Test]
        public static void TestHeartbeatInvalidKey()
        {
            Heartbeat heartbeat = new Heartbeat("INVALIDKEY", 1);

            System.Threading.Thread.Sleep(61 * 1000);

            Assert.AreEqual(Reporter.errors, 1);
        }
    }
}
