using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}