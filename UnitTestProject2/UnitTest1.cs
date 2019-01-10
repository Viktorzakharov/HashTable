using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;
using System.Text;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        public static PowerSet<string> table = GenerateTable(17);
        public static PowerSet<string>[] testTables = GenerateTestTables(17);

        [TestMethod]
        public void TestPut()
        {
            var value = "f";
            var slot = table.SeekSlot(value);
            table.Put(value);
            Assert.AreEqual(table.Slots[slot], value);
            Assert.IsTrue(table.Get(value));

            table.Put(value);
            var valueCount = 0;
            foreach (var e in table.Slots)
                if (e == value) valueCount++;
            Assert.AreEqual(1, valueCount);
        }

        [TestMethod]
        public void TestRemove()
        {
            var value = "f";
            var slot = table.SeekSlot(value);
            Assert.IsTrue(table.Remove(value));
            Assert.AreEqual(default(string), table.Slots[slot]);
            Assert.IsFalse(table.Remove(value));
        }

        [TestMethod]
        public void TestIntersection()
        {
            var intersection = GetByteSum(new string[] { "b", "d" });
            var intersectionResult = GetByteSum(table.Intersection(testTables[0]).Slots);
            Assert.AreEqual(intersection, intersectionResult);
            Assert.AreEqual(0, table.Intersection(testTables[3]).Slots.Length);
        }

        [TestMethod]
        public void TestUnion()
        {
            var union = GetByteSum(new string[] { "f", "b", "g", "d", "a", "c", "e" });
            var unionResult = GetByteSum(table.Union(testTables[0]).Slots);
            Assert.AreEqual(union, unionResult);
            Assert.AreEqual(GetByteSum(table.Slots), GetByteSum(table.Union(new PowerSet<string>(17)).Slots));
        }

        [TestMethod]
        public void TestDifference()
        {
            var difference = GetByteSum(new string[] { "a", "c", "e" });
            var differenceResult = GetByteSum(table.Difference(testTables[0]).Slots);
            Assert.AreEqual(difference, differenceResult);
            Assert.AreEqual(0, table.Difference(testTables[2]).Slots.Length);
        }

        [TestMethod]
        public void TestIsSubset()
        {
            Assert.IsTrue(table.IsSubset(testTables[1]));
            Assert.IsTrue(table.IsSubset(new PowerSet<string>(0)));
            Assert.IsFalse(table.IsSubset(testTables[2]));
            Assert.IsFalse(table.IsSubset(testTables[0]));
        }

        public int GetByteSum(string[] array)
        {
            var result = 0;
            foreach (var e in array)
                if (e != null)
                {
                    byte[] text = Encoding.UTF8.GetBytes(e);
                    foreach (var item in text) result += item;
                }
            return result;
        }

        public static PowerSet<string> GenerateTable(int size)
        {
            var table = new PowerSet<string>(size);
            table.Put("a");
            table.Put("b");
            table.Put("c");
            table.Put("d");
            table.Put("e");
            return table;
        }

        public static PowerSet<string>[] GenerateTestTables(int size)
        {
            var tableArray = new PowerSet<string>[4];

            tableArray[0] = new PowerSet<string>(size);
            tableArray[0].Put("f");
            tableArray[0].Put("b");
            tableArray[0].Put("g");
            tableArray[0].Put("d");

            tableArray[1] = new PowerSet<string>(size);
            tableArray[1].Put("b");
            tableArray[1].Put("c");
            tableArray[1].Put("d");

            tableArray[2] = new PowerSet<string>(size);
            tableArray[2].Put("a");
            tableArray[2].Put("b");
            tableArray[2].Put("c");
            tableArray[2].Put("d");
            tableArray[2].Put("e");
            tableArray[2].Put("f");
            tableArray[2].Put("g");

            tableArray[3] = new PowerSet<string>(size);
            tableArray[3].Put("x");
            tableArray[3].Put("y");
            tableArray[3].Put("z");

            return tableArray;
        }
    }
}
