using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPutRemove()
        {
            var table = GenerateTable();
            Assert.IsTrue(table.Put("f"));
            Assert.IsFalse(table.Put("f"));
            Assert.IsTrue(table.Remove("f"));
            Assert.IsFalse(table.Remove("f"));
        }

        [TestMethod]
        public void TestSetActions()
        {
            var table = GenerateTable();
            var checkTable = GenerateTestTable();

            var intersection = new string[] { "b", "d" };
            var intersectionResult = table.Intersection(checkTable[0]);
            Assert.AreEqual(GetByteSum(intersection), GetByteSum(intersectionResult));
            Assert.AreEqual(0, table.Intersection(checkTable[3]).Length);

            var union = new string[] { "f", "b", "g", "d", "a", "c", "e" };
            var unionResult = table.Union(checkTable[0]);
            Assert.AreEqual(GetByteSum(union), GetByteSum(unionResult));
            unionResult = table.Union(new HashTable.HashTable());
            Assert.AreEqual(GetByteSum(table.Array), GetByteSum(unionResult));

            var difference = new string[] { "a", "c", "e"};
            var differenceResult = table.Difference(checkTable[0]);
            Assert.AreEqual(GetByteSum(difference), GetByteSum(differenceResult));
            Assert.AreEqual(0, table.Difference(checkTable[2]).Length);

            Assert.IsTrue(table.Issubset(checkTable[1]));
            Assert.IsFalse(table.Issubset(checkTable[2]));
            Assert.IsFalse(table.Issubset(checkTable[0]));
        }       

        public int GetByteSum(string[] array)
        {
            var result = 0;
            foreach(var e in array)
                if (e != null)
                {
                    byte[] text = Encoding.UTF8.GetBytes(e);
                    foreach (var item in text)
                        result += item;
                }
            return result;
        }

        public HashTable.HashTable GenerateTable()
        {
            var table = new HashTable.HashTable();
            table.Put("a");
            table.Put("b");
            table.Put("c");
            table.Put("d");
            table.Put("e");
            return table;
        }

        public HashTable.HashTable[] GenerateTestTable()
        {
            var tableArray = new HashTable.HashTable[4];

            tableArray[0] = new HashTable.HashTable();
            tableArray[0].Put("f");
            tableArray[0].Put("b");
            tableArray[0].Put("g");
            tableArray[0].Put("d");

            tableArray[1] = new HashTable.HashTable();
            tableArray[1].Put("b");
            tableArray[1].Put("c");
            tableArray[1].Put("d");

            tableArray[2] = new HashTable.HashTable();
            tableArray[2].Put("a");
            tableArray[2].Put("b");
            tableArray[2].Put("c");
            tableArray[2].Put("d");
            tableArray[2].Put("e");
            tableArray[2].Put("f");
            tableArray[2].Put("g");

            tableArray[3] = new HashTable.HashTable();
            tableArray[3].Put("x");
            tableArray[3].Put("y");
            tableArray[3].Put("z");

            return tableArray;
        }
    }
}
