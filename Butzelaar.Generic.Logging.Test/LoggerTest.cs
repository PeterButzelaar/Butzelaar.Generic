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
            string retVal = Logger.GetCallingAssemblyName();
            Assert.AreEqual("Butzelaar.Generic.Logging.Test", retVal);
        }

        [TestMethod]
        public void SetDetailsProperty_TextDetails()
        {
            const string details = "Test details";
            Logger.SetDetailsProperty(details);
            Assert.AreEqual(GlobalContext.Properties["details"], details);
        }

        [TestMethod]
        public void SetDetailsProperty_NullDetails()
        {
            Logger.SetDetailsProperty(null);
            Assert.AreEqual(GlobalContext.Properties["details"], string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void GetLogMethodFromLevel_LogNull()
        {
            Logger.GetLogMethodFromLevel(null, Level.Error);
        }

        [TestMethod]
        public void GetLogMethodFromLevel_LevelDebug()
        {
            ILog logger = LogManager.GetLogger(string.Empty);
            Logger.GetLogMethodFromLevel(logger, Level.Debug);
        }

        #endregion
    }
}