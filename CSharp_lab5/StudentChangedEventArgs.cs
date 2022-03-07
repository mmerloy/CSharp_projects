using System;


namespace ConsoleApp2
{
    class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public string collection_name { get; set; }
        public Action action_type { get; set; }
        public string property_name { get; set; }
        public TKey key { get; set; }
        public StudentsChangedEventArgs(string collection_name_value, Action action_type_value, string property_name_value, TKey key_value)
        {
            collection_name = collection_name_value;
            action_type = action_type_value;
            property_name = property_name_value;
            key = key_value;
        }
        public override string ToString()
        {
            return collection_name + " \t" + action_type.ToString() + " \t" + property_name + "\t " + key.ToString();
        }
    }
}
