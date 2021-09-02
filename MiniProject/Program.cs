using System;
using System.Collections;
using System.Text;
using MiniProject.Models;
using MiniProject.Services;

namespace MiniP

{
    class Program
    {
        static void Main(string[] args)
        {


            HumanResourceManger humanResourceManager = new HumanResourceManger();
            baseWord(humanResourceManager);

        }

        #region baseWord
        static void baseWord(HumanResourceManger humanResourceManager)
        {
            do
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("1- Departmentle bagli emeliyyatlar  ucun");
                Console.WriteLine("2- Iscilerle bagli emeliyyatlar ucun");
                Console.WriteLine("========================================\n");


                string choose = Console.ReadLine();
                int chooseNumbers;

                int.TryParse(choose, out chooseNumbers);
                switch (chooseNumbers)
                {
                    case 1:
                        DepartmentWork(humanResourceManager);
                        break;

                    case 2:
                        EmployeeWork(humanResourceManager);
                        break;

                    default:
                        Console.Clear();
                        break;
                }

            } while (true);
        }
        #endregion

        #region DepartmentWork
        static void DepartmentWork(HumanResourceManger humanResourceManager)
        {
            do
            {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("1 - Departmentler listini  gostermek ucun");
                Console.WriteLine("2 - Departmentde deyisiklik etmek ucun");
                Console.WriteLine("3 - Department yaratmaq ucun");
                Console.WriteLine("4 - Esas menyuya qayitmaq ucun");
                Console.WriteLine("------------------------------------------\n");


                string choose = Console.ReadLine();
                int chooseNumbers;

                int.TryParse(choose, out chooseNumbers);
                switch (chooseNumbers)
                {
                    case 1:
                        GetDepartmentInformasiya(humanResourceManager);
                        break;

                    case 2:

                        editDepartment(humanResourceManager);
                        break;

                    case 3:
                        createDepartment(humanResourceManager);
                        break;
                    case 4:
                        baseWord(humanResourceManager);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (true);
        }
        #endregion
        #region EmployeeWork
        static void EmployeeWork(HumanResourceManger humanResourceManager)
        {
            do
            {
                Console.WriteLine("\n````````````````````````````````````````````````````");
                Console.WriteLine("1 - Iscilerin listinine baxmaq ucun");
                Console.WriteLine("2 - Departmentdeki iscilerin lsitini gostermek ucun");
                Console.WriteLine("3 - Isci elave etmek ucun");
                Console.WriteLine("4 - Isciler uzerinde deyisikler ucun");
                Console.WriteLine("5 - Departmentden isci silmek ucun");
                Console.WriteLine("6 - Esas menyuya qayitmaq ucun");
                Console.WriteLine("````````````````````````````````````````````````````\n");


                string choose = Console.ReadLine();
                int chooseNumbers;
                int.TryParse(choose, out chooseNumbers);
                switch (chooseNumbers)
                {
                    case 1:
                        GetEmployees(humanResourceManager);
                        break;

                    case 2:
                        GetemployeesDepartment(humanResourceManager);
                        break;

                    case 3:
                        addEmployee(humanResourceManager);
                        break;
                    case 4:
                        editEmployee(humanResourceManager);
                        break;
                    case 5:
                        removeEmployee(humanResourceManager);
                        break;

                    case 6:
                        baseWord(humanResourceManager);

                        break;
                    default:
                        Console.Clear();
                        break;
                }

            } while (true);
        }
        #endregion
        #region GetDepartmentInformasiya
        static void GetDepartmentInformasiya(HumanResourceManger humanResourceManager)
        {
            foreach (Department item in humanResourceManager.Departments)
            {
                if (item.Employees.Count > 0)
                {
                    Console.WriteLine($"{item.Name}{item.Employees.Count}{item.CalcSalaryAverage()}");
                }
                else
                {
                    Console.WriteLine($"{item.Name} adli departmentde isci yoxdur");
                }
            }
        }
        #endregion
        #region createDepartment
        static void createDepartment(HumanResourceManger humanResourceManager)
        {
            Department department1 = new Department();
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Departmentin adinin girin.");
                string DepartName = Console.ReadLine();
                Console.WriteLine("Zehmet olmasa isci limiti girin");

                string empLimit = Console.ReadLine();
                int workerLimit;

                while (!int.TryParse(empLimit, out workerLimit))
                {
                    Console.WriteLine("Zehmet olmasa isci limiti girin!!!");
                    empLimit = Console.ReadLine();
                    int.TryParse(empLimit, out workerLimit);
                }
                Console.WriteLine("Iscinin maas limitini daxil edin");

                string salaryLimit = Console.ReadLine();
                int salaryCount;

                while (!int.TryParse(salaryLimit, out salaryCount))
                {
                    Console.WriteLine("Zehmet olmasa isci limiti girin!!!");
                    salaryLimit = Console.ReadLine();
                    int.TryParse(salaryLimit, out salaryCount);
                }
                department1.Name = DepartName;
                department1.Salarylimit = salaryCount;
                department1.WorkerLimit = workerLimit;


                humanResourceManager.AddDepartment(department1);
                check = true;
            }


        }
        #endregion

        #region EditedDepartment
        static void editDepartment(HumanResourceManger humanResourceManager)
        {
            Console.WriteLine("Axradiginiz departmentin adini girin!!!");
            string name = Console.ReadLine();

            Department department = humanResourceManager.Departments.Find(h => h.Name.ToLower() == name.ToLower());
            if (department == null)
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Daxil etdiyiniz adda department yoxdur!!!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

                return;
            }

            Console.WriteLine($"Departmentin adi: {department.Name} Deparmentin maas limiti: {department.Salarylimit} Departmentin isci limiti: {department.WorkerLimit} ");
            Console.WriteLine("Departmentin yeni adi:");
            string newName = Console.ReadLine();
            Console.WriteLine("Departmentin maas limitini girin:");
            string salaryLimit = Console.ReadLine();
            int Salaryx;
            while (!int.TryParse(salaryLimit, out Salaryx))
            {
                Console.WriteLine("Departmentin maas limitini girin:");
                salaryLimit = Console.ReadLine();
                int.TryParse(salaryLimit, out Salaryx);
            }
            Console.WriteLine("Departmentin isci limitini girin");
            string empLimit = Console.ReadLine();
            int Limity;
            while (!int.TryParse(empLimit, out Limity))
            {
                Console.WriteLine("Departmentin isci limitini girin");
                empLimit = Console.ReadLine();
                int.TryParse(empLimit, out Limity);
            }

            department.Name = newName;
            department.Salarylimit = Salaryx;
            department.WorkerLimit = Limity;

            Console.WriteLine("Department uzerinde olunan deyisiklik ugurla basa catdi");


        }
        #endregion


        #region GetEmployees
        static void GetEmployees(HumanResourceManger humanResourceManager)
        {
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                Department departmentEmployees = humanResourceManager.Departments[i];
                for (int x = 0; x < departmentEmployees.Employees.Count; x++)
                {
                    Console.WriteLine($"\n Iscinin nomresi: {departmentEmployees.Employees[x].No} \n Iscinin Ad Soyadi: {departmentEmployees.Employees[x].Fullname} \n Iscinin maasi: {departmentEmployees.Employees[x].Salary} \n Departmentin adi: {departmentEmployees.Employees[x].DepartmentName}");
                }
            }
        }
        #endregion

        #region GetEmployeesDepartment
        static void GetemployeesDepartment(HumanResourceManger humanResourceManager)
        {

            Console.WriteLine("Zehmet olmasa departmentin adin daxil edin");
            string Department = Console.ReadLine();

            Department DEPARTMENT = humanResourceManager.Departments.Find(t => t.Name.ToLower() == Department.ToLower());

            if (DEPARTMENT != null)
            {

                for (int i = 0; i < DEPARTMENT.Employees.Count; i++)
                {
                    Console.WriteLine($"\n Iscinin nomresi: {DEPARTMENT.Employees[i].No} \n Iscinin adi ve soyadi: {DEPARTMENT.Employees[i].Fullname} \n Iscinin yerlesdiyi pazisya: {DEPARTMENT.Employees[i].Position} \n Iscinin aldigi maas: {DEPARTMENT.Employees[i].Salary} ");
                }
            }
            else
            {
                Console.WriteLine("Bu adda department yoxdur");
            }

        }
        #endregion

        #region AddEmployee
        static void addEmployee(HumanResourceManger humanResourceManager)
        {

            Console.WriteLine("Fullname-i girin!!!");
            string fullname = Console.ReadLine();


            Console.WriteLine("Iscinin pozisyasini daxil edin!!");
            string position = Console.ReadLine();

            Console.WriteLine("Maasini daxil edin!!!");
            string salary = Console.ReadLine();
            int salarySA;
            while (!int.TryParse(salary, out salarySA))
            {
                Console.WriteLine("Maawi daxil edin!!");
                salary = Console.ReadLine();
                int.TryParse(salary, out salarySA);
            }

            Console.WriteLine("Departmanin adini daxil ediniz!!!");
            string DepartmentName = Console.ReadLine();
            Employee employee1 = new Employee(DepartmentName);

            employee1.Fullname = fullname;
            employee1.Salary = salarySA;
            employee1.Position = position;

            humanResourceManager.AddEmployee(employee1, DepartmentName);
        }
        #endregion

        #region EditEmployee
        static void editEmployee(HumanResourceManger humanResourceManager)
        {

            Console.WriteLine("Deyisiklik  etmek ucun istediyiniz iscinin nomresini daxil edin!!!");
            string EmpNumbers = Console.ReadLine();
            bool corrt = false;
            string SaName = " ";
            int SaSalary = 0;
            string SaPosition = " ";




            int satet = 0;
            int atset = 0;
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                for (int x = 0; x < humanResourceManager.Departments[i].Employees.Count; x++)
                {
                    if (EmpNumbers == humanResourceManager.Departments[i].Employees[x].No)
                    {
                        corrt = true;
                        if (corrt)
                        {
                            SaName = humanResourceManager.Departments[i].Employees[x].Fullname;
                            SaSalary = humanResourceManager.Departments[i].Employees[x].Salary;
                            SaPosition = humanResourceManager.Departments[i].Employees[x].Position;

                            satet = i;
                            atset = x;
                        }
                        break;
                    }
                }
            }
            if (corrt)
            {
                Console.WriteLine($"{SaName}{SaSalary}{SaPosition}");
                Console.WriteLine("Yeni maasi girmeyiniz xayis olunur");
                string CmSalary = Console.ReadLine();
                int XmSalary;
                while (!int.TryParse(CmSalary, out XmSalary))
                {
                    Console.WriteLine("Yeni maasi girmeyiniz xayis olunur");
                    CmSalary = Console.ReadLine();
                    int.TryParse(CmSalary, out XmSalary);
                }
                Console.WriteLine("Yeni vezifeni girmeyiniz xayis olunur");
                string YeniPosition = Console.ReadLine();

                humanResourceManager.Departments[satet].Employees[atset].Position = YeniPosition;
                humanResourceManager.Departments[satet].Employees[atset].Salary = XmSalary;
            }
            else
            {
                baseWord(humanResourceManager);
            }
        }
        #endregion

        #region removeEmployee
        static void removeEmployee(HumanResourceManger humanResourceManager)
        {
            Console.WriteLine("Silmek istediyiniz departmentin adini girin");
            string SaName = Console.ReadLine();

            Department department = humanResourceManager.Departments.Find(p => p.Name == SaName);

            Console.WriteLine("Silmek istediyiniz iscinin No-sun giriniz");
            string NUMBERS = Console.ReadLine();
            if (department != null)
            {
                for (int i = 0; i < department.Employees.Count; i++)
                {
                    if (department.Employees[i].No == NUMBERS)
                    {
                        department.Employees.Remove(department.Employees[i]);

                        Console.WriteLine("Isci ugurlu shekilde silindi");
                        return;
                    }
                }
            }
        }
        #endregion
    }
}



