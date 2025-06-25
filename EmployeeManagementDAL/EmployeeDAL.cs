using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOemployee;

namespace EmployeeManagementDAL
{
    public class EmployeeDAL
    {
        string filepath = @"C:\Users\Ali Ahmad\source\repos\EmployeeManagementsystem\Employees.txt";
        public void Save(DTOemp employee)
        {

            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                string data = $"{employee.Id},{employee.Name},{employee.Age},{employee.DepName},{employee.Salary},{employee.Date}";
                writer.WriteLine(data);
            }
        }

        public List<DTOemp> GetAll()
        {
            List<DTOemp> employees = new List<DTOemp>();
            try {

                using (StreamReader reader = new StreamReader(filepath))
                {
                    string data = reader.ReadLine();

                    while (data != null)
                    {
                        string[] empInfo = data.Split(',');
                        DTOemp emp = new DTOemp();
                        emp.Id = int.Parse(empInfo[0]);
                        emp.Name = empInfo[1];
                        emp.Age = int.Parse(empInfo[2]);
                        emp.DepName = empInfo[3];
                        emp.Salary = int.Parse(empInfo[4]);
                        emp.Date = DateTime.Parse(empInfo[5]);

                        employees.Add(emp);
                        data = reader.ReadLine();
                    }
                }

            return employees;
        }
            catch (Exception ex)
            {
                throw new Exception("Error reading employee data", ex);
            }
        }

        public DTOemp GetempbyID(int id)
        {
            List<DTOemp> employees = GetAll();

            foreach (DTOemp emp in employees)
            {
                if (emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }

        public bool Delete(int id)
        {
            List<DTOemp> employees = GetAll();
            bool found = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees.Remove(employees[i]);
                    found = true;
                    break;
                }

            }

            if (found)
            {
                using (StreamWriter writer = new StreamWriter(filepath, append:false))
                {
                    foreach (DTOemp emp in employees)
                    {
                        string data = $"{emp.Id},{emp.Name},{emp.Age},{emp.DepName},{emp.Salary},{emp.Date}";
                        writer.WriteLine(data);
                    }
                }
            }

            return found;
        }

        public bool Update(DTOemp empp)
        {
            List<DTOemp> employees = GetAll();
            bool found = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == empp.Id)
                {
                    employees[i] = empp;
                    found = true;
                    break;
                }

            }

            if (found)
            {
                using (StreamWriter writer = new StreamWriter(filepath, append:false))
                {
                    foreach (DTOemp emp in employees)
                    {
                        string data = $"{emp.Id},{emp.Name},{emp.Age},{emp.DepName},{emp.Salary},{emp.Date}";
                        writer.WriteLine(data);
                    }
                }
            }

            return found;
        }
    }
}
