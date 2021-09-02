using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    class Employee
    {
        private static int _counter = 100;
        
        public static void ALQR()
        {
            _counter = 1000;
        }

        public string DepartmentName;


        public Employee()
        {
        }

        public Employee(string depart): this ()
        {
            DepartmentName = depart;
            _counter++;
            No = DepartmentName.Substring(0, 2).ToUpper() + _counter;
        }



        private string _no;
        public string No
        {
            get
            {
                return _no;
            }
            set
            {
                _no = value;
            }
        }

        public string Fullname;

        private string _position;
        //iscinin vezifesi ucun method
        public string Position
        {
            get
            {
                return _position;
            }
              set
            {
                if (correctName(value))
                {
                    _position = value;
                }
                else
                {
                    Console.WriteLine("Iscinin vezifesi");
                }
            }
        }

        private bool correctName(string name)
        {
            if (name .Length<2)
            {
                return false;
            }
            foreach (char item in name)
            {
                if (!Char.IsLetter(item))
                {
                    return false;
                }
            }
            return true;
        }
        //iscinin massi ucun method
        private int _salary;
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if(value>250)
                {
                    _salary = value;
                }
                else
                {
                    Console.WriteLine("Iscinin maasi 250-den asagi ola bilmez");
                }
            }
        }
    }
}
