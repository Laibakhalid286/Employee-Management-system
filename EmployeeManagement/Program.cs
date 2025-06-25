using System;
using System.Collections.Generic;
using DTOdepartment;
using DTOemployee;
using EmployeeManagementBLL;

namespace MainMethod
{
     class EmployeeManagementPL
    {
        EmployeeBLL empBLL = new EmployeeBLL();
        DepartmentBLL depBLL = new DepartmentBLL();

        static void Main()
        {
            EmployeeManagementPL empPL = new EmployeeManagementPL();
            while (true)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. List All Employees");
                Console.WriteLine("2. Add New Employee");
                Console.WriteLine("3. Update Employee Details");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Search Employees");
                Console.WriteLine("6. Manage Departments");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        empPL.ListAllEmployees();
                        break;
                    case "2":
                        empPL.AddNewEmployee();
                        break;
                    case "3":
                        empPL.UpdateEmployee();
                        break;
                    case "4":
                        empPL.DeleteEmployee();
                        break;
                    case "5":
                        empPL.SearchEmployees();
                        break;
                    case "6":
                        empPL.ManageDepartments();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        public  void ListAllEmployees()
        { 
            List<DTOemp> employees = empBLL.GetAll();
            Console.WriteLine("\nEmployees:");
            foreach (DTOemp emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Age: {emp.Age}, Dept: {emp.DepName}, DOJ: {emp.Date}");
            }
        }

        public  void AddNewEmployee()
        {
            DTOemp emp = new DTOemp();
            Console.Write("Enter Employee ID:");
            emp.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee Name:");
            emp.Name = Console.ReadLine();
            Console.Write("Enter Employee Age:");
            emp.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Department Name:");
            emp.DepName = Console.ReadLine();
            Console.Write("Enter Date of Joining (yyyy-mm-dd):");
            emp.Date = DateTime.Parse(Console.ReadLine());

            if (empBLL.CreateEmployee(emp))
                Console.WriteLine("Employee added successfully.");
            else
                Console.WriteLine("Failed to add employee.");
        }

        public  void UpdateEmployee()
        {
            DTOemp emp = new DTOemp();
            Console.Write("Enter Employee ID to update: ");
            emp.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Department Name: ");
            emp.DepName = Console.ReadLine();
            Console.Write("Enter New Salary: ");
            emp.Salary = int.Parse(Console.ReadLine());

            if (empBLL.UpdateEmployee(emp))
                Console.WriteLine("Employee updated successfully.");
            else
                Console.WriteLine("Failed to update employee.");
        }

        public  void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            if (empBLL.DeleteEmployee(id))
                Console.WriteLine("Employee deleted successfully.");
            else
                Console.WriteLine("Failed to delete employee.");
        }

        public  void SearchEmployees()
        {
            Console.WriteLine("Enter Employee details for search");
            Console.Write("ID:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Department:");
            string dep = Console.ReadLine();
            Console.Write("Joining Date (yyyy-MM-dd):");
            string dateInput = Console.ReadLine();
            DateTime date= DateTime.Parse(dateInput);

            List<DTOemp> result = empBLL.SearchEmployee(id, name, dep, date);
            Console.WriteLine("\nSearch Results:");
            foreach (DTOemp emp in result)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.DepName}, DOJ: {emp.Date}");
            }
        }

        public  void ManageDepartments()
        {
            Console.WriteLine("Department Management");
            Console.WriteLine("1. List Departments");
            Console.WriteLine("2. Add Department");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Delete Department");
            Console.Write("Enter your Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListDepartments();
                    break;
                case "2":
                    AddDepartment();
                    break;
                case "3":
                    UpdateDepartment();
                    break;
                case "4":
                    DeleteDepartment();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        public void ListDepartments()
        {
            List<DTOdep> deps = depBLL.GetAll();
            Console.WriteLine("\nDepartments:");
            foreach (DTOdep dep in deps)
            {
                Console.WriteLine($"ID: {dep.Id}, Name: {dep.Name}, Desc: {dep.Description}");
            }
        }

        public  void AddDepartment()
        {
            DTOdep dep = new DTOdep();
            Console.Write("Enter Department ID: ");
            dep.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Department Name: ");
            dep.Name = Console.ReadLine();
            Console.Write("Enter Department Description: ");
            dep.Description = Console.ReadLine();

            if (depBLL.CreateDepartment(dep))
                Console.WriteLine("Department added successfully.");
            else
                Console.WriteLine("Failed to add department.");
        }

        public  void UpdateDepartment()
        {
            DTOdep dep = new DTOdep();
            Console.Write("Enter Department ID to update: ");
            dep.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Department Name: ");
            dep.Name = Console.ReadLine();
            Console.Write("Enter New Department Description: ");
            dep.Description = Console.ReadLine();

            if (depBLL.UpdateDepartment(dep))
                Console.WriteLine("Department updated successfully.");
            else
                Console.WriteLine("Failed to update department.");
        }
        public  void DeleteDepartment()
        {
            Console.Write("Enter Department ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            if (depBLL.DeleteDepartment(id))
                Console.WriteLine("Department deleted successfully.");
            else
                Console.WriteLine("Failed to delete department.");
        }
    }
}
