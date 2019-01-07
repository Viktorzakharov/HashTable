using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

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
            Assert.AreEqual(table.func("abc", table.size), result);
        }

        [TestMethod]
        public void TestSeekSlot()
        {
            var table = GenerateTable();
            var result = table.SeekSlot("abc");
            Assert.IsNull(table.slots[result]);
        }

        [TestMethod]
        public void TestPut()
        {
            var table = GenerateTable();
            var slot = table.SeekSlot("abc");
            var result = table.Put("abc");
            if (slot < 0) Assert.AreEqual(-1, result);
            else
            {
                Assert.AreEqual(slot, result);
                Assert.AreEqual("abc", table.slots[slot]);
            }
        }

        [TestMethod]
        public void TestFind()
        {
            var table = GenerateTable();
            if (table.Put("abc") != -1)
            {
                var slot = table.FindSlot("abc", "abc");
                var result = table.Find("abc");
                Assert.AreEqual(slot, result);
                Assert.AreEqual("abc", table.slots[result]);
            }
            else Assert.AreEqual(-1, table.Find("abc"));
        }

        public HashTable GenerateTable()
        {
            var table = new HashTable(17, 3, GenerateFunctions());
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

        public HashFunction[] GenerateFunctions()
        {
            return new HashFunction[]
            { (line, size) => (5 * HashTable.LineInByte(line) + 7) % 28 % size,
              (line, size) => (10 * HashTable.LineInByte(line) + 2) % 50 % size,
              (line, size) => (17 * HashTable.LineInByte(line) + 3) % 100 % size,
              (line, size) => (23 * HashTable.LineInByte(line) + 245) % 284 % size,
              (line, size) => (115 * HashTable.LineInByte(line) + 54) % 176 % size
            };
        }
    }
}
