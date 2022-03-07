using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Journal
    {
        private List<JournalEntry> journal_entries = new List<JournalEntry>();
        public void AddNewEntry(object sender, EventArgs e)
        {
            var entry_args = (StudentsChangedEventArgs<string>)e;
            var new_entry = new JournalEntry(entry_args.collection_name, entry_args.action_type, entry_args.property_name, entry_args.key.ToString());
            journal_entries.Add(new_entry);
        }
        public override string ToString()
        {
            string s = "";
            foreach (var entry in journal_entries)
            {
                s += entry.ToString() + "\n";
            }
            return s;
        }
    }
}
