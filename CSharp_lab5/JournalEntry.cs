
namespace ConsoleApp2
{
    class JournalEntry
    {
        public string collection_name { set; get; }
        public Action action_type { set; get; }
        public string property_name { set; get; }
        public string el_key { set; get; }
        public JournalEntry(string collection_name_value, Action action_type_value, string property_name_value, string el_key_value)
        {
            collection_name = collection_name_value;
            action_type = action_type_value;
            property_name = property_name_value;
            el_key = el_key_value;
        }
        public override string ToString()
        {
            return collection_name + " \t" + action_type.ToString() + " " + property_name + " \t" + el_key;
        }
    }
}
