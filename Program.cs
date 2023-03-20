using static System.Console;
// СОБЫТИЙНЫЕ СРЕДСТВА ДОСТУПА

//event  DelegateName EventName
//{
//add {/*код добавления события в цепочку событий*/ }
//remove { /*код удаления события в цепочку событий*/ }
//}

/*using System;
using System.Collections.Generic;

namespace SimpleProject
{
    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public void Exam(string task)
        {
            Console.WriteLine("Student " + LastName + " solved the " + task);
        }
    }
    class Teacher
    {
        SortedList<int, ExamDelegate> _sortedEvents = new SortedList<int, ExamDelegate>();
        Random _rand = new Random();
        public event ExamDelegate examEvent
        {
            add // добавление подписчиков
            {
                for (int key; ;)
                {
                    key = _rand.Next();
                    if (!_sortedEvents.ContainsKey(key)) // если ноль значит равны, а ключи должны быть разные
                    {
                        _sortedEvents.Add(key, value);
                        break;
                    }
                }
            }
            remove
            {
                _sortedEvents.RemoveAt(_sortedEvents.IndexOfValue(value));
            }
        }
        public void Exam(string task)
        {
            foreach (int item in _sortedEvents.Keys)
            {
                if (_sortedEvents[item] != null)
                {
                    _sortedEvents[item](task);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> group = new List<Student> {
new Student {
FirstName = "John",
LastName = "Miller",
BirthDate = new DateTime(1997,3,12)
},
new Student {
FirstName = "Candice",
LastName = "Leman",
BirthDate = new DateTime(1998,7,22)
},
new Student {
FirstName = "Joey",
LastName = "Finch",
BirthDate = new DateTime(1996,11,30)
},
new Student {
FirstName = "Nicole",
LastName = "Taylor",
BirthDate = new DateTime(1996,5,10)
}
};
            Teacher teacher = new Teacher();
            foreach (Student item in group)
            {
                teacher.examEvent += item.Exam;
            }
            Student student = new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1998, 10, 12)
            };
           // 
            teacher.Exam("Task #1");
            Console.WriteLine();
            teacher.examEvent += student.Exam;
            WriteLine("******************************");
            teacher.Exam("Task #1");
            Console.WriteLine();
            WriteLine("******************************");
            teacher.examEvent -= student.Exam;
            teacher.Exam("Task #2");
        }
    }
}*/



// АНОНОИМНЫЕ МЕТОДЫ

////// пример 1

/*using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_AnonymousMethod_1
{

    *//* delegate[(param)]
     {тело выполняемого кода}
    *//*
    class Program
    {
        delegate String TestAnonymousDelegate(String str);

        static void Main(string[] args)
        {
            String strMiddle = ", средняя часть,";

            TestAnonymousDelegate anonymousDelegate = delegate (String parameter)
            {
                parameter += strMiddle;
                parameter += " а эта часть строки добавлена в конец.\n";
                return parameter;
            };

           // Console.WriteLine(anonymousDelegate("Начало строки"));

            anonymousDelegate += delegate (String parameter)
             {
                 return "end function";
             };
            Console.WriteLine(anonymousDelegate("Начало строки"));

        }
    }
}*/


//


/*using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_AnonymousMethod_1
{
    
    class Student
    {
        public event EventHandler Exam_event;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Student(string FirstName_, string LastName_, DateTime BirthDate_)
        {
            FirstName = FirstName_;
            LastName = LastName_;
            BirthDate = BirthDate_;
        }
        public void Exam()
        {
            if (Exam_event!=null)
            {
                Exam_event(this, EventArgs.Empty);
            }
        }
    }

    class Program
    {
        *//*static void Student_Exam_Event(object sender, EventArgs e)
        {
            WriteLine("Экзамен сдан\n");
        }*//*
        static void Main(string[] args)
        {
            Student student = new Student("John", "Doe", new DateTime(1998, 10, 12));

            //student.Exam_event += new EventHandler(Student_Exam_Event);
            student.Exam_event += delegate (object sender, EventArgs e)
            {
                WriteLine("Экзамен сдан\n");
            };
            student.Exam();
        }

    }
}*/



// 



using System;
//using static System.Console;
namespace Lesson_8_AnonymousMethod_2
{
    public delegate double AnonimDelegateDouble(double x, double y);
    public delegate void AnonimDelegateInt(int n);
    public delegate void AnonimDelegateVoid();
    class Dispacher
    {
        public event AnonimDelegateDouble eventDouble;
        public event AnonimDelegateInt eventVoid;
        public double OnEventDouble(double x, double y) //anonimdelegatedouble
        {
            if (eventDouble != null)
            {
                return eventDouble(x, y);
            }
            throw new NullReferenceException();
        }
        public void OnEventVoid(int n = 0) // anonimdelegateint or anonimdelegatevoid 
            {
        {
            if (eventVoid != null) 
                eventVoid(n);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tThe use of events");
            Dispacher dispacher = new Dispacher();
            // анонимный метод

            dispacher.eventDouble += delegate (double a, double b) // описываем функцию сразу через анонимный метод
              {
                  if (b != 0)
                  {
                      return a / b;
                  }
                  throw new DivideByZeroException();
              };
           /* dispacher.eventDouble +=
             (double a, double b) =>
             {
                 if (b != 0)
                 {
                     return a / b;
                 }
                 throw new DivideByZeroException();
             };*/
            double n1 = 5.7, n2 = 3.2;
            Console.WriteLine(n1 + " / " + n2 + " = " + dispacher.OnEventDouble(n1, n2)); // вызов
            Console.WriteLine(" Using a local variable");
            int number = 5;// анонимный метод
            dispacher.eventVoid += /*delegate*/ (int n) => { WriteLine(number + " + " + n + " = " + (number + n)); }; // лямбда выражение
            dispacher.OnEventVoid(); // вызов, передастся ноль
            dispacher.OnEventVoid(6);
            Console.WriteLine("\tThe use of a delegate");
            //AnonimDelegateVoid voidDel = new AnonimDelegateVoid( delegate  { Console.WriteLine("Ok!"); }); // 1
            //AnonimDelegateVoid voidDel = new AnonimDelegateVoid( /*delegate*/ () => { Console.WriteLine("Ok!"); }); // 2
            AnonimDelegateVoid voidDel =  () => { Console.WriteLine("Ok!"); }; // 3
            // анонимный метод
            voidDel += delegate { Console.WriteLine("Bye!"); };
            voidDel(); // вызов
        }
    }
}