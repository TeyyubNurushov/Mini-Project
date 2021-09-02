using System;
using System.Collections.Generic;
using System.Text;
using MiniProject.Interface;
using MiniProject.Models;

namespace MiniProject.Services
{
    class HumanResourceManger : IHumanResourceManager
    {
        private List<Department> _departments;
        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
        }

        public HumanResourceManger()
        {
            _departments = new List<Department>();
        }

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }
        //Departmente isci elave etmek ucun method yazrg
        public void AddEmployee(Employee employee, string departmentName)
        {
            Employee employer = new Employee();
            employer.Fullname = employee.Fullname;
            employer.Salary = employee.Salary;
            employer.Position = employee.Position;
            employer.No = employee.No;

            foreach (Department item in Departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    if (item.WorkerLimit > item.Employees.Count)
                    {
                        if (item.WorkerLimit > item.Employees.Count)
                        {
                            if (employer.Salary > 250)
                            {
                                try
                                {
                                    if (employer.Position.Length >= 2)
                                    {
                                        item.Employees.Add(employer);
                                        Console.WriteLine("Isci sirkete elave olundu tesekkurler");

                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name}  departamentde  isci ucun qalan yermiz yoxdur basqa vaxd gelersiz");
                    }
                }
            }
        }
        //Departmentde deyisiklik aparmag ucun istifade olunanlar
        public void EditDepartments(string Name, Department department)
        {
            foreach (Department department1 in _departments)
            {
                if (department1.Name.ToLower() == Name.ToLower())
                {
                    department1.Name = department.Name;
                }
                else
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Axtardiginiz adda department yoxdur");
                    Console.WriteLine("-------------------------------------\n");
                }
            }
        }


        //isciler ucun deyisikklik aparmag methodu
        public void EditEmployee(string num, string fullname, int salary, string position, Employee employee)
        {
            Employee EditedEmployee = new Employee();
            foreach (Department item in _departments)
            {
                for (int i = 0; i < item.Employees.Count; i++)
                {
                    if (item.Employees[i].No == num)
                    {

                        Console.WriteLine($"{item.Employees[i].Fullname}{item.Employees[i].Salary}  {item.Employees[i].Position}");

                        EditedEmployee.Fullname = employee.Fullname;
                        EditedEmployee.Salary = employee.Salary;
                        EditedEmployee.Position = employee.Position;

                    }
                    else
                    {
                        Console.WriteLine("Axtardiginiz adda isci yoxdur Tesekkurler");
                        return;
                    }
                }
            }
        }

        public List<Department> GetDepartments()
        {
            return Departments;
        }

        //Departmentde isci silmek ucun lazim olanlar

        public void RemoveEmployee(string num, string departmentName)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    for (int i = 0; i < item.Employees.Count; i++)
                    {
                        if (item.Employees[i].No == num)
                        {
                            item.Employees.Remove(item.Employees[i]);
                            Console.WriteLine("Sildiyiniz isci departmentde ugurla vidalasdi :)");
                        }
                        else
                        {
                            Console.WriteLine("Axtardiginiz isci yoxdur!!!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Axtardiginiz adda department yoxdur!!!");
                }

            }
        }

    }
}

