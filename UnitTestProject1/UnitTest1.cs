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
            table.Put("abc");
            Assert.AreEqual("abc", table.Array[294 % table.Size]);
        }

        [TestMethod]
        public void TestFind()
        {
            var table = GenerateTable();
            table.Put("abc");
            var result = table.Find("abc");
            Assert.AreEqual(294 % table.Size, result);
            Assert.AreEqual("abc", table.Array[result]);
        }

        public HashTable.HashTable GenerateTable()
        {
            var table = new HashTable.HashTable();
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
