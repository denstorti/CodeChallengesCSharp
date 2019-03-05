using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MyHashMap<K, V>
    {

        int count;
        V[] data;
        private readonly int hashSeed;
        private readonly int MAX_SIZE = 10000;

        /** Initialize your data structure here. */
        public MyHashMap(int size = 10000)
        {
            MAX_SIZE = size;
            count = 0;
            hashSeed = this.GetHashCode();
            data = new V[MAX_SIZE];

        }

        public int hash(K key)
        {
            int temp = key.GetHashCode();
            int positivehash = (temp % MAX_SIZE) < 0 ? -(temp % MAX_SIZE) : (temp % MAX_SIZE);
            return positivehash;
        }

        /** value will always be non-negative. */
        public void Put(K key, V value)
        {
            int hashKey = hash(key);
            
            data[hashKey] = value;
            
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public V Get(K key)
        {
            int hashKey = hash(key);

            if (data[hashKey] != null)
            {
                return (V)data[hashKey];
            }
            else
            {
                return default(V);
            }
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(K key)
        {
            int hashKey = hash(key);

            if (data[hashKey] != null)
            {
                data[hashKey] = default(V);
            }
        }
    }

    /**
     * Your MyHashMap object will be instantiated and called as such:
     * MyHashMap obj = new MyHashMap();
     * obj.Put(key,value);
     * int param_2 = obj.Get(key);
     * obj.Remove(key);
     */
}
