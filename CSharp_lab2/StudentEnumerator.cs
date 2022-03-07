using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp2
{
    class StudentEnumerator: IEnumerator
    {
        private ArrayList tests;
        private ArrayList exams;
        private int pos = -1;
        public StudentEnumerator(ArrayList _tests, ArrayList _exams)
        {
            tests = _tests;
            exams = _exams;
        }
        public bool MoveNext()
        {
            pos++;
            for (; pos < tests.Count; pos++)
            {
                foreach (Exam exam in exams)
                {
                    if (exam.Name == ((Test)tests[pos]).Name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Reset()
        {
            pos = -1;
        }
        public object Current
        {
            get
            {
                try
                {
                    return ((Test)tests[pos]).Name;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
