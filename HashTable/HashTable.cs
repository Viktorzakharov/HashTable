using System.Text;

namespace HashTable
{
    public class Cache
    {
        public readonly int Size;
        public readonly int Step;
        public object[] KeyArray;
        public object[] ValueArray;
        public int[] Appeals;
        public Database Data;

        public Cache()
        {
            Size = 17;
            Step = 3;
            KeyArray = new object[Size];
            ValueArray = new object[Size];
            Appeals = new int[Size];
            Data = new Database();
            Data.Create();
        }

        public int HashFun(object value)
        {
            var result = 0;
            byte[] text = Encoding.UTF8.GetBytes(value.ToString());
            for (int i = 0; i < text.Length; i++)
                result += text[i];
            return result % 17;
        }

        public int[] IsKey(object key)
        {
            var slot = HashFun(key);
            for (int i = 0; i < Size; i++)
            {
                var item = KeyArray[slot % Size];
                if (key.Equals(item)) return new int[] { 1, slot % Size };
                if (item is null) return new int[] { 0, slot % Size };
                slot += Step;
            }
            return new int[] { -1, MinIndex() };
        }

        public object GetValue(object key)
        {
            var slot = IsKey(key);
            if (slot[0] == 1)
            {
                AppealsManage(slot[1]);
                return ValueArray[slot[1]];
            }
            if (slot[0] == -1)
            { 
                PutKeyValue(slot[1], key);
                Appeals[slot[1]] = 8;
                return ValueArray[slot[1]];                
            }
            PutKeyValue(slot[1], key);
            Appeals[slot[1]] = 8;
            return ValueArray[slot[1]];
        }

        public void AppealsManage(int slot)
        {
            Appeals[slot] += 18;
            for (int i = 0; i < Appeals.Length; i++)
                if (KeyArray[i] != null)
                    Appeals[i] --;
        }

        public int MinIndex()
        {
            var min = Appeals[0];
            var minIndex = 0;

            for (int i = 0; i < Appeals.Length; i++)
                if (min > Appeals[i])
                {
                    min = Appeals[i];
                    minIndex = i;
                }
            return minIndex;
        }

        public void PutKeyValue(int index, object key)
        {
            KeyArray[index] = key;
            ValueArray[index] = Data.Data[key];
            AppealsManage(index);
        }
    }
}
