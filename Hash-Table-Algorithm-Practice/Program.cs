using System;
using System.Collections.Generic;

namespace Hash_Table_Algorithm_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash = new HashTable();
            hash.put(0, "a");
            hash.put(0, "b");
            hash.put(5, "c");
            Console.WriteLine(hash.get(5));
        }

        public static string FirstNonRepeatedCharacter(string input)
        {
            var dictionary = new Dictionary<char, int>();
            input = input.ToLower();
            foreach (var letter in input)
            {
                if (dictionary.ContainsKey(letter)) dictionary[letter]++;
                else dictionary.Add(letter, 0);
            }
            foreach (var value in dictionary)
            {
                if (value.Value == 0) return value.Key.ToString();
            }
            return "There are not any non-repeated characters.";
        }

        public static string FirstRepeatedCharacter(string input)
        {
            input.ToLower();
            var dict = new Dictionary<char, int>();
            foreach (var letter in input)
            {
                if (!dict.ContainsKey(letter)) dict.Add(letter, 1);
                else dict[letter]++;
            }
            foreach (var letter in dict) if (letter.Value >= 2) return letter.Key.ToString();
            return "There are not any repeated characters";
        }

        public class HashTable{
            int size = 5;
            LinkedList<Entry>[] table;

            public HashTable()
            {
                table = new LinkedList<Entry>[size];
            }

            public void put(int key, string value)
            {
                var slot = getSlot(key);
                if (table[slot] == null) table[slot] = new LinkedList<Entry>();
                foreach (var item in table[slot])
                {
                    if (item.Key == key)
                    {
                        item.Value = value;
                        return;
                    }
                }
                table[slot].AddLast(new Entry(key, value));
            }

            public string get(int key)
            {
                var slot = getSlot(key);
                if (table[slot] == null) return "";
                else foreach (var item in table[slot]) if (item.Key == key) return item.Value;
                return "";
            }

            private int getSlot(int key)
            {
                return key % size;
            }
        }

        public class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }

            public Entry(int key, string val)
            {
                this.Key = key;
                this.Value = val;
            }
        }

    }
}
