

namespace ConsoleApp2
{
    [System.Serializable]
    class Test
    {
        //открытые автореализуемые свойства, доступные для чтения и записи:
        public string Name { get; set; }
        public bool result { get; set; }

        //конструктор c параметрами типа string и bool для инициализации свойств класса 
        public Test(string _Name, bool _result)
        {
            Name = _Name;
            result = _result;
        }

        //конструктор без параметров, инициализирующий все свойства класса
        //некоторыми значениями по умолчанию
        public Test()
        {
            Name = "A";
            result = false;
        }


        //перегруженная(override) версия виртуального метода string ToString() для
        //формирования строки со значениями всех свойств класса.
        public override string ToString()
        { return "\n Предмет: "+ Name + "   Зачет? " + result.ToString(); }


        public object DeepCopy()
        {
            return new Test(Name, result);
        }
    }
}

   
