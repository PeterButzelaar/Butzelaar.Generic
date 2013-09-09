using System;
using Butzelaar.Generic.Logging.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net;

namespace Butzelaar.Generic.Logging.Test
{
    [TestClass]
    public class LoggerTest
    {
        #region Log

        [TestMethod]
        public void LogDebug_Message()
        {
            Logger.Log(Level.Debug, "This is a debug test");
        }

        [TestMethod]
        public void LogDebug_Message_Null()
        {
            Logger.Log(Level.Debug, null);
        }

        [TestMethod]
        public void LogDebug_MessageLogger()
        {
            Logger.Log(Level.Debug, GetType().Assembly.GetName().Name, "This is a debug test");
        }

        [TestMethod]
        public void LogDebug_NullNull()
        {
            Logger.Log(Level.Debug, null, null);
        }

        [TestMethod]
        public void LogDebug_MessageException()
        {
            Logger.Log(Level.Debug, "This is an exception test", null, new Exception());
        }

        #endregion

        #region Helpers

        [TestMethod]
        public void GetCallingAssembly_LogginTest()
        {
            var privateType = new PrivateType(typeof(Logger));
            var response = privateType.InvokeStatic("GetEntryAssemblyName");

            Assert.AreEqual(response, "Butzelaar.Generic.Logging");
        }

        [TestMethod]
        public void SetDetailsProperty_TextDetails()
        {
            const string details = "Test details";
            var privateType = new PrivateType(typeof(Logger));
            privateType.InvokeStatic("SetDetailsProperty", details);

            Assert.AreEqual(ThreadContext.Properties["details"].ToString(), details);
        }

        [TestMethod]
        public void SetDetailsProperty_NullDetails()
        {
            var privateType = new PrivateType(typeof(Logger));
            privateType.InvokeStatic("SetDetailsProperty", new object[] { null } );

            Assert.AreEqual(ThreadContext.Properties["details"].ToString(), string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLogMethodFromLevel_LogNull()
        {
            var privateType = new PrivateType(typeof(Logger));
            privateType.InvokeStatic("GetLogMethodFromLevel", null, Level.Error);
        }

        [TestMethod]
        public void GetLogMethodFromLevel_LevelDebug()
        {
            ILog logger = LogManager.GetLogger(string.Empty);
            var privateType = new PrivateType(typeof(Logger));
            privateType.InvokeStatic("GetLogMethodFromLevel", logger, Level.Debug);
        }

        #endregion
    }
}