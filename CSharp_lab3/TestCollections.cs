using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);

    class TestCollections<TKey, TValue>
    {
        List<TKey> keys;
        List<string> strs;
        Dictionary<TKey, TValue> values;
        Dictionary<string, TValue> valuesNamed;
        GenerateElement<TKey, TValue> GenerateElement;


        public TestCollections(GenerateElement<TKey, TValue> generateElement, int N)
        {
            GenerateElement = generateElement;
            values = new Dictionary<TKey, TValue>();
            keys = new List<TKey>();
            strs = new List<string>();
            valuesNamed = new Dictionary<string, TValue>();
            for (int i = 0; i < N; i++)
            {
                KeyValuePair<TKey, TValue> pair = generateElement.Invoke(i);
                values.Add(pair.Key, pair.Value);
                valuesNamed.Add(pair.Key.ToString(), pair.Value);
                keys.Add(pair.Key);
                strs.Add(pair.Key.ToString());
            }
        }
        public void Search(KeyValuePair<TKey, TValue> value)
        {
            string stKey = value.Key.ToString();
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            long[] times = new long[5];
            watch.Start();
            keys.Contains(value.Key);
            watch.Stop();
            times[0] = watch.ElapsedMilliseconds;
            watch.Restart();
            strs.Contains(stKey);
            watch.Stop();
            times[1] = watch.ElapsedMilliseconds;
            watch.Restart();
            values.ContainsKey(value.Key);
            watch.Stop();
            times[2] = watch.ElapsedMilliseconds;
            watch.Restart();
            valuesNamed.ContainsKey(stKey);
            watch.Stop();
            times[3] = watch.ElapsedMilliseconds;
            watch.Restart();
            valuesNamed.ContainsValue(value.Value);
            watch.Stop();
            times[4] = watch.ElapsedMilliseconds;
            Console.WriteLine($"\n list of Tkey = {times[0]}ms list of strings = {times[1]}ms \n Dictionary by tkey = {times[2]}ms Dictionary by string key = {times[3]}ms \n Dictionary by value = {times[4]}ms\n");
        }



    }
}