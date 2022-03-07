using System;
using System.Collections.Generic;
using ConsoleApp2;

namespace ConsoleApplication2
{
    class ExamComparer : IComparer<Exam>
    {
        public int Compare(Exam x, Exam y)
        {
            return x.Examdate.CompareTo(y.Examdate);
        }
    }
}
