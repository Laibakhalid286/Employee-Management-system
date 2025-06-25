using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementDAL;
using DTOdepartment;
using DTOemployee;

namespace EmployeeManagementBLL
{
    public class EmployeeBLL
    {
        DepartmentDAL depDAL = new DepartmentDAL();
        EmployeeDAL empDAL = new EmployeeDAL();
            public bool CreateEmployee(DTOemp employee)
        {
            bool exists = false;
            List<string> validnames = depDAL.DepNames();

            foreach(string name in validnames)
            {
                if (name == employee.DepName)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                Console.WriteLine("The department deos not exists so the employee can't be created.");
                return false;
            }

            if (empDAL.GetempbyID(employee.Id) != null)
            {
                Console.WriteLine("This is a duplicate ID");
                return false;
            }

            empDAL.Save(employee);
            return true;

        }

        public bool UpdateEmployee(DTOemp employee)
        {
            DTOemp employeeExists = empDAL.GetempbyID(employee.Id);
            if (employeeExists == null)
            {
                Console.WriteLine("The employee does not exist");
                return false;
            }

            List<string> validDepartments = depDAL.DepNames();
            if (!validDepartments.Contains(employee.DepName))
            {
                Console.WriteLine("The department does not exist, so the employee can't be updated.");
                return false;
            }

            employeeExists.DepName = employee.DepName;
            employeeExists.Salary = employee.Salary;

            return empDAL.Update(employeeExists);  
        }

        public bool DeleteEmployee(int id)
        {
            DTOemp employeeExists = empDAL.GetempbyID(id);

            if (employeeExists == null)
            {
                Console.WriteLine("The employee does not exist");
                return false;
            }

            return empDAL.Delete(id);
        }

        public List<DTOemp> SearchEmployee(int id,string name,string depname,DateTime date)
        {
            List<DTOemp> employees = empDAL.GetAll();
            List<DTOemp> res = new List<DTOemp>();
         
            foreach(DTOemp emp in employees)
            {
                bool found = true;

                if( id != emp.Id)
                {
                    found = false;
                }

                
                    if (emp.Name.ToLower() != name.ToLower())
                    {
                        found = false;
                    }
                

                    if (emp.DepName.ToLower() != depname.ToLower())
                    {
                        found = false;
                    }

                if (emp.Date != date)
                {
                    found = false;
                }
                if (found)
                {
                    res.Add(emp);
                }
            }

            return res;
        }

        public void Save(DTOemp emp)
        {
            EmployeeDAL empDal = new EmployeeDAL();
            empDal.Save(emp);
        }

        public List<DTOemp> GetAll()
        {
            EmployeeDAL empDal = new EmployeeDAL();
            return empDal.GetAll();
        }

    }
}
