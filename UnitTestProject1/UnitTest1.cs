using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            Assert.IsTrue(CheckSet(intersection, intersectionResult));
            Assert.AreEqual(0, table.Intersection(checkTable[3]).Count);

            var union = new string[] { "f", "b", "g", "d", "a", "c", "e" };
            var unionResult = table.Union(checkTable[0]);
            Assert.IsTrue(CheckSet(union, unionResult));
            Assert.IsTrue(CheckSet(table.Array, table.Union(new HashTable.HashTable())));

            var difference = new string[] { "a", "c", "e"};
            var differenceResult = table.Union(checkTable[0]);
            Assert.IsTrue(CheckSet(difference, differenceResult));
            Assert.AreEqual(0, table.Difference(checkTable[2]).Count);

            Assert.IsTrue(table.Issubset(checkTable[1]));
            Assert.IsFalse(table.Issubset(checkTable[2]));
            Assert.IsFalse(table.Issubset(checkTable[0]));
        }       

        public bool CheckSet(string[] expected, List<string> actual)
        {
            for (int i = 0; i < actual.Count; i++)
                if (expected[i] != actual[i]) return false;
            return true;
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

            tableArray[0].Put("f");
            tableArray[0].Put("b");
            tableArray[0].Put("g");
            tableArray[0].Put("d");

            tableArray[1].Put("b");
            tableArray[1].Put("c");
            tableArray[1].Put("d");

            tableArray[2].Put("a");
            tableArray[2].Put("b");
            tableArray[2].Put("c");
            tableArray[2].Put("d");
            tableArray[2].Put("e");
            tableArray[2].Put("f");
            tableArray[2].Put("g");

            tableArray[3].Put("x");
            tableArray[3].Put("y");
            tableArray[3].Put("z");

            return tableArray;
        }
    }
}
