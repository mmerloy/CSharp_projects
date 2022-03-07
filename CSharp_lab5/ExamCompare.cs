
using System.Collections.Generic;


namespace ConsoleApp2
{
    class ExamCompare : IComparer<Exam>
    {
        public int Compare(Exam x, Exam y)
        {
            return x.Examdate.CompareTo(y.Examdate);
        }
    }
}
