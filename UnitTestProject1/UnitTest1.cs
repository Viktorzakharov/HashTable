using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAppealsIncrease()
        {
            var cache = new Cache();
            Program.GenerateCache(cache);
            var lastAppeal = cache.Appeals[0];
            cache.GetValue(cache.KeyArray[0]);
            Assert.AreEqual(lastAppeal + cache.AppealValueGet - 1, cache.Appeals[0]);
        }

        [TestMethod]
        public void TestGetValue()
        {
            var cache = new Cache();
            var random = Program.GenerateCache(cache);
            var newKey = Program.NewKey(cache, random);
            var minIndex = cache.MinIndex();
            var lastKey = cache.KeyArray[minIndex];
            cache.GetValue(newKey);
            Assert.IsFalse(Find(cache, lastKey));
            Assert.IsTrue(newKey.Equals(cache.KeyArray[minIndex]));
        }

        public static bool Find(Cache cache, object key)
        {
            foreach (var e in cache.KeyArray)
                if (key.Equals(e)) return true;
            return false;
        }
    }
}
