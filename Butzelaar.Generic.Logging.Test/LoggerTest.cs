using Butzelaar.Generic.Logging.Enumeration;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            Logger.Log(Level.Debug, this.GetType().Assembly.GetName().Name, "This is a debug test");
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
            var retVal = Logger.GetCallingAssemblyName();
            Assert.AreEqual("Butzelaar.Generic.Logging.Test", retVal);
        }

        [TestMethod]
        public void SetDetailsProperty_TextDetails()
        {
            var details = "Test details";
            Logger.SetDetailsProperty(details);
            Assert.AreEqual(GlobalContext.Properties["details"], details);
        }

        [TestMethod]
        public void SetDetailsProperty_NullDetails()
        {
            string details = null;
            Logger.SetDetailsProperty(details);
            Assert.AreEqual(GlobalContext.Properties["details"], string.Empty);
        }

        #endregion
    }
}
