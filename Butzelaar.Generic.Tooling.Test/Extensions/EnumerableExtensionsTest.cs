using Butzelaar.Generic.Tooling.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace Butzelaar.Generic.Tooling.Test.Extensions
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void ForEach_StringBuilderAppendEmpty()
        {
            var sb = new StringBuilder();
            IEnumerable<string> list = new List<string>();
            list.ForEach(s => sb.Append(s));
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [TestMethod]
        public void ForEach_StringBuilderAppendNull()
        {
            var sb = new StringBuilder();
            IEnumerable<string> list = new List<string> { null };
            list.ForEach(s => sb.Append(s));
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [TestMethod]
        public void ForEach_StringBuilderAppendOneTitle()
        {
            const string title = "ForEach";
            var sb = new StringBuilder();
            IEnumerable<string> list = new List<string> { title };
            list.ForEach(s => sb.Append(s));
            Assert.AreEqual(sb.ToString(), title);
        }

        [TestMethod]
        public void ForEach_StringBuilderAppendMoreTitles()
        {
            const string title = "ForEach";
            var sb = new StringBuilder();
            IEnumerable<string> list = new List<string> { title, title };
            list.ForEach(s => sb.Append(s));
            Assert.AreEqual(sb.ToString(), title + title);
        }
    }
}
