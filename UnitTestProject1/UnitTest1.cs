using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHashFun()
        {
            var table = GenerateTable();
            var result = table.HashFun("abc");
            Assert.AreEqual(294 % table.Size, result);
        }

        [TestMethod]
        public void TestSeekSlot()
        {
            var table = GenerateTable();
            var result = table.SeekSlot("abc", null);
            Assert.IsNull(table.Array[result]);
        }

        [TestMethod]
        public void TestPut()
        {
            var table = GenerateTable();
            var slot = table.SeekSlot("abc", null);
            var result = table.Put("abc");
            if (slot < 0) Assert.IsFalse(result);
            else
            {
                Assert.IsTrue(result);
                Assert.AreEqual("abc", table.Array[slot]);
            }
        }

        [TestMethod]
        public void TestFind()
        {
            var table = GenerateTable();
            if (table.Put("abc"))
            {
                var slot = table.SeekSlot("abc", "abc");
                var result = table.Find("abc");
                Assert.AreEqual(slot, result);
                Assert.AreEqual("abc", table.Array[result]);
            }
            else Assert.AreEqual(-1, table.Find("abc"));
        }

        public HashTable.Nativedictionary GenerateTable()
        {
            var table = new HashTable.Nativedictionary();
            table.Put("a");
            table.Put("b");
            table.Put("c");
            table.Put("d");
            table.Put("e");
            table.Put("f");
            table.Put("g");
            table.Put("h");
            table.Put("i");
            table.Put("j");
            return table;
        }
    }
}
