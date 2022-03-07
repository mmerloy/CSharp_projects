using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class StudentCollection<TKey>
    {
        private Dictionary<TKey, Student> students;
        private KeySelector<TKey> KeyCreator;

        public StudentCollection(KeySelector<TKey> selector)
        {
            students = new Dictionary<TKey, Student>();
            KeyCreator = selector;
        }

        public void AddDefaults()
        {
            Student[] range = new Student[] { new Student(), new Student( new Person("Arcadii", "Merenov", new DateTime(1999, 04, 06)),Education.Specialist, 24) };
             AddStudents(range);
        }

        public void AddStudents(params Student[] newStudents)
        {
            foreach (var student in newStudents)
            {  students.Add(KeyCreator.Invoke(student), student);  }
        }

        public override string ToString()
        {
            string output = "";
            foreach (var student in students.Values)
            {   output += student.ToString() + "\n...............................\n";   }

            return output;
        }

        public virtual string ToShortString()
        {
            string output = "";
            foreach (var student in students.Values)
            {  output += student.ToShortString() + "\n...............................\n";   }

            return output;
        }

        public double GetMaxGrade()
        {
            if (students.Count == 0) return 0;
            return students.Values.ToList().ConvertAll(e => e.Grade).Max();
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {  return students.Where(e => e.Value.form == value); }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation
        {
            get
            {   return from Student in students group Student by Student.Value.form;  }
        }


    }
}
