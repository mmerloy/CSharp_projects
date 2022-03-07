using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp2
{
    class StudentEnumerator: IEnumerator
    {
        private List<Exam> ListExam;
        private List<Test> ListTest;
        int index = 0;
        int indexInExam = -1;
        public StudentEnumerator(List<Exam> ListExam, List<Test> ListTest)
        {
            this.ListExam = ListExam;
            this.ListTest = ListTest;
        }


        public object Current
        {
            get
            {  return ListExam[indexInExam];  }
        }

        public bool MoveNext()
        {
            for (int i = indexInExam + 1; i < ListExam.Count; i++)
            {
                foreach (var test in ListTest)
                {
                    if (test.Name == ListExam[i].Name)
                    {        indexInExam = i;
                             return true;        }

                }
            }
            return false;
        }

        public void Reset()
        {
            if (ListExam.Count > 0) { index = 0; indexInExam = 0; }
            else { index = -1; indexInExam = -1; }

        }
    }
















    //public bool MoveNext()
    //{
    //    pos++;
    //    for (; pos < tests.Count; pos++)
    //    {
    //        foreach (Exam exam in exams)
    //        {
    //            if (exam.Name == ((Test)tests[pos]).Name)
    //            {
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}
    //public void Reset()
    //{
    //    pos = -1;
    //}
    //public object Current
    //{
    //    get
    //    {
    //        try
    //        {
    //            return ((Test)tests[pos]).Name;
    //        }
    //        catch (IndexOutOfRangeException)
    //        {
    //            throw new InvalidOperationException();
    //        }
    //    }
    //}
}

