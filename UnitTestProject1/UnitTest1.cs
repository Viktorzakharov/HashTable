using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsKey()
        {
            var table = GenerateTable();
            Assert.IsTrue(table.IsKey("g"));
            Assert.IsFalse(table.IsKey("z"));
        }

        [TestMethod]
        public void TestPut()
        {
            var table = GenerateTable();
            var key = "k";
            var value = "kk";
            var slot = table.FindSlot(key);
            table.Put(key, value);
            Assert.IsTrue(table.IsKey(key));
            Assert.AreEqual(key, table.slots[slot]);
            Assert.AreEqual(value, table.values[slot]);
            Assert.AreEqual(value, table.Get(key));

            value = "zz";
            table.Put(key, value);
            Assert.IsTrue(table.IsKey(key));
            Assert.AreEqual(key, table.slots[slot]);
            Assert.AreEqual(value, table.values[slot]);
            Assert.AreEqual(value, table.Get(key));
        }

        [TestMethod]
        public void TestGet()
        {
            var table = GenerateTable();
            var key = "k";
            Assert.IsFalse(table.IsKey(key));
            Assert.AreEqual(default(string), table.Get(key));

            key = "h";
            var value = "hh";
            Assert.IsTrue(table.IsKey(key));
            Assert.AreEqual(value, table.Get(key));
        }

        NativeDictionary<string> GenerateTable()
        {
            var table = new NativeDictionary<string>(17);
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
