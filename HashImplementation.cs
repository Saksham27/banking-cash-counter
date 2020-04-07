using System;
using System.Collections.Generic;
using System.Text;

namespace BankingCashCounter
{
    internal class HashNode<T> {
        public string key;
        public T value;
        public HashNode<T> next;
        public HashNode<T> previous;
    }
    
    class HashImplementation<T>
    {
        private HashNode<T>[] hashTable;
        private readonly int tableSize;

        /// <summary>
        /// constructor method to initialize Hash table
        /// </summary>
        /// <param name="maxTableSize"></param>
        public HashImplementation(int maxTableSize)
        {
            this.tableSize = maxTableSize;
            this.hashTable = new HashNode<T>[tableSize];
        }

        /// <summary>
        /// Hsh fucntion to generate index for key
        /// </summary>
        /// <param name="key"> key </param>
        /// <returns> returns index from the space based on some calculation </returns>
        private int HashFunction(string key)
        {
            int index = 7;
            int asciiValue = 0;
            for (int i = 0; i < key.Length; i++)
            {
                asciiValue = (int)key[i] * i;
                index = index * 31 + asciiValue;
            }
            return index % tableSize;
        }

        /// <summary>
        /// Inserts a value with key to table
        /// </summary>
        /// <param name="key"> key </param>
        /// <param name="value"> value of the key </param>
        public void Insert(string key, T value)
        {
            int generateIndex = HashFunction(key);
            HashNode<T> node = hashTable[generateIndex];

            // if hash table is empty
            if (node == null)
            {
                hashTable[generateIndex] = new HashNode<T>() { key = key, value = value };
                return;
            }

            // if key already exists
            if (node.key == key)
            {
                Console.WriteLine("Can't use same key!");
                return;
            }
                
            // loop through the hash table and if key exists return or assign key to value
            while (node.next != null)
            {
                node = node.next;
                if (node.key == key)
                {
                    Console.WriteLine("Can't use same key!");
                    return;
                }
            }

            HashNode<T> newNode = new HashNode<T>() { key = key, value = value, previous = node, next = null };
            node.next = newNode;
        }

        /// <summary>
        /// to get the value of given key
        /// </summary>
        /// <param name="key"> key </param>
        /// <returns> value assosiated with key </returns>
        public T GetValue(string key)
        {
            int generateIndex = HashFunction(key);
            HashNode<T> node = hashTable[generateIndex];
            while (node != null)
            {
                if (node.key == key)
                {
                    return node.value;
                }
                else
                {
                    node = node.next;
                }               
            }
            Console.WriteLine("Don't have the key in hash!");
            return default;
        }
    }

    }
}
