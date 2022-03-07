
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace ConsoleApp2
{
    class StudentCollection<TKey>
    {
        private Dictionary<TKey, Student> students;
        private KeySelector<TKey> KeyCreator;
        public string collection_name { get; set; }

        public StudentCollection(KeySelector<TKey> selector)
        {
            students = new Dictionary<TKey, Student>();
            KeyCreator = selector;
        }
       

        public void AddDefaults()
        {
            Student stud = new Student();
            TKey stud_key = KeyCreator(stud);
            students = new Dictionary<TKey, Student>()
            {
                {stud_key, stud}
            };
            OnStudentsChanged(Action.Add, "( Добавляем коллекцию )\t", stud_key);
            stud.PropertyChanged += EventControl;
        }

       
        public void AddStudents(params Student[] newStudents)
        {
            foreach (var student in newStudents)
            {
                students.Add(KeyCreator(student), student);
                OnStudentsChanged(Action.Add, "( Добавляем коллекцию)\t", KeyCreator(student));
                student.PropertyChanged += EventControl;
            }
        }
     
        public override string ToString()
        {
            string output = "";
            foreach (var student in students.Values)
            { output += student.ToString() + "\n"; }

            return output;
        }

        public virtual string ToShortString()
        {
            string output = "";
            foreach (var student in students.Values)
            { output += student.ToShortString() + "\n"; }

            return output;
        }

        public double GetMaxGrade()
        {
            if (students.Count == 0) return 0;
            return students.Values.ToList().ConvertAll(e => e.Grade).Max();
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        { return students.Where(e => e.Value.form == value); }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation
        {
            get
            { return from Student in students group Student by Student.Value.form; }
        }

        public IEnumerator<KeyValuePair<TKey, Student>> GetEnumerator()
        {
            return students.GetEnumerator();
        }
        public event StudentsChangedHandler<TKey> StudentsChanged;
        public void EventControl(object subject, EventArgs e)
        {
            var pr = (PropertyChangedEventArgs)e;
            var st = (Student)subject;
            var item = students.First(kvp => kvp.Value == st);
            var st_key = item.Key;
            OnStudentsChanged(Action.Property, pr.PropertyName.ToString(), st_key);
        }
        private void OnStudentsChanged(Action action_type, string property_name, TKey key)
        {
            if (StudentsChanged != null)
            {
                StudentsChanged(this, new StudentsChangedEventArgs<TKey>(collection_name, action_type, property_name, key));
            }
        }
        public bool Remove(Student st)
        {
            var item = students.First(kvp => kvp.Value == st);
            var st_key = item.Key;
            if (students.ContainsKey(st_key))
            {
                students.Remove(st_key);
                OnStudentsChanged(Action.Remove, "(Удаляем коллекцию)\t ", st_key);
                st.PropertyChanged -= EventControl;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
