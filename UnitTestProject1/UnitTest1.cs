using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsKey()
        {
            var table = GenerateTable();
            Assert.AreEqual(1, table.IsKey("f")[0]);
            Assert.AreEqual(-1, table.IsKey("abcd")[0]);
        }

        [TestMethod]
        public void TestPut()
        {
            var table = GenerateTable();
            Assert.IsTrue(table.Put("k", "kk"));
            Assert.AreEqual("kk", table.Get("k"));
            Assert.IsTrue(table.Put("c", "test"));
            Assert.AreEqual("test", table.Get("c"));

        }

        [TestMethod]
        public void TestGet()
        {
            var table = GenerateTable();
            Assert.AreEqual("bb", table.Get("b"));
            Assert.AreEqual(null, table.Get("z"));
        }

        public NativeDictionary GenerateTable()
        {
            var table = new NativeDictionary();
            table.Put("a", "aa");
            table.Put("b", "bb");
            table.Put("c", "cc");
            table.Put("d", "dd");
            table.Put("e", "ee");
            table.Put("f", "ff");
            table.Put("g", "gg");
            table.Put("h", "hh");
            table.Put("i", "ii");
            table.Put("j", "jj");
            return table;
        }
    }
}
