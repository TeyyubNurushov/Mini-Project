using System;
using System.Collections.Generic;
using System.Text;
using MiniProject.Models;


namespace MiniProject.Interface
{
    interface IHumanResourceManager
    {
        public List<Department>Departments { get; }

        public void AddDepartment(Department department);

        public List<Department> GetDepartments();

        public void EditDepartments(string Name, Department department);


        public void AddEmployee(Employee employee, string departmentname);

        public void RemoveEmployee(string num, string departmentName);
        public void EditEmployee(string num, string fullname, int salary, string position, Employee employee);
    }
}
