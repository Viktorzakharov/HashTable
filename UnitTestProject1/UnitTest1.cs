using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;
using System.Text;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public NativeCache<string> cache;

        public UnitTest1()
        {
            cache = new NativeCache<string>(17);
            cache.data = CreateData();
            GenerateCache(cache);           
        }

        [TestMethod]
        public void TestAppealsIncrease()
        {
            var lastHit = cache.hits[0];
            cache.Get(cache.slots[0]);
            Assert.AreEqual(lastHit + cache.hitsGet - 1, cache.hits[0]);
        }

        [TestMethod]
        public void TestGetValue()
        {
            var newKey = NewKey(cache);
            var minIndex = cache.MinIndex();
            var lastKey = cache.slots[minIndex];
            var lastValue = cache.values[minIndex];
            cache.Get(newKey);
            Assert.AreEqual(-1, cache.FindSlot(lastKey));
            Assert.AreEqual(newKey, cache.slots[minIndex]);
            Assert.AreNotEqual(lastValue, cache.values[minIndex]);
        }

        static Dictionary<string, string> CreateData()
        {
            var symbol = "0";
            var dataLength = 81;
            var data = new Dictionary<string, string>();

            for (int i = 0; i < dataLength; i++)
            {
                data.Add(symbol, symbol + symbol);
                var symbolByte = Encoding.UTF8.GetBytes(symbol);
                symbolByte[0]++;
                symbol = Encoding.UTF8.GetString(symbolByte);
            }
            return data;
        }

        void GenerateCache(NativeCache<string> cacheGen)
        {
            var random = new Random();
            for (int i = 0; i < 80; i++)
                cacheGen.Get(Encoding.UTF8.GetString(new byte[] { (byte)random.Next(48, 128) }));
        }

        static string NewKey(NativeCache<string> cache)
        {
            foreach (var e in cache.data.Keys)
                if (cache.FindSlot(e) == -1) return e;
            return null;
        }
    }
}
