
using System.Collections.Generic;

using System.Collections;

namespace ConsoleApp2
{
    class StudentEnumerator: IEnumerator
    {
        private List<Exam> ListExam;
        private List<Test> ListTest;
       
        private int indexInExam = -1;
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
             indexInExam = -1; 
        }
    }



}

