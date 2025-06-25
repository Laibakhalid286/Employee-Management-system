using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOdepartment;
using DTOemployee;

namespace EmployeeManagementDAL
{
    public class DepartmentDAL
    {
        string filepath= @"C:\Users\Ali Ahmad\source\repos\EmployeeManagementsystem\Departments.txt";
        public void Save(DTOdep dep)
        {
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                string data = $"{dep.Id},{dep.Name},{dep.Description}";
                writer.WriteLine(data);
                writer.Close();
            }
        }

        public List<DTOdep> GetAll()
        {
            
            List<DTOdep> departments = new List<DTOdep>();
            try
            {

                using (StreamReader reader = new StreamReader(filepath))
                {
                    string data = reader.ReadLine();

                    while (data != null)
                    {
                        string[] depInfo = data.Split(',');
                        DTOdep depp = new DTOdep();
                        depp.Id = int.Parse(depInfo[0]);
                        depp.Name = depInfo[1];
                        depp.Description = depInfo[2];


                        departments.Add(depp);
                        data = reader.ReadLine();
                    }
                }
                    return departments;
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading dep data", ex);
            }
        }


        public List<string> DepNames()
        {
            List<DTOdep> departments = GetAll();
            List<string> names = new List<string>();

            foreach(DTOdep dep in departments)
            {
                names.Add(dep.Name);
            }
            return names;
        }

        public bool Delete(int id)
        {
            List<DTOdep> departments = GetAll();
            bool found = false;

            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Id == id)
                {
                    departments.Remove(departments[i]);
                    found = true;
                    break;
                }

            }

            if (found) {

                using (StreamWriter writer = new StreamWriter(filepath, append:false))
                {
                    foreach (DTOdep dep in departments)
                    {
                        string data = $"{dep.Id},{dep.Name},{dep.Description}";
                        writer.WriteLine(data);
                    }
                }
            }

            return found;
        }

        public bool Update(DTOdep depp)
        {
            List<DTOdep> departments = GetAll();
            bool found = false;

            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Id == depp.Id)
                {
                    departments[i].Name=depp.Name;
                    departments[i].Description = depp.Description;

                    found = true;
                    break;
                }

            }

            if (found)
            {
                using (StreamWriter writer = new StreamWriter(filepath, append: false)) { 
                    foreach (DTOdep dep in departments)
                    {
                        string data = $"{dep.Id},{dep.Name},{dep.Description}";
                        writer.WriteLine(data);
                    }
                 }
            }

            return found;
        }

        public DTOdep GetdepbyID(int id)
        {
            List<DTOdep> departments = GetAll();

            foreach (DTOdep dep in departments)
            {
                if (dep.Id == id)
                {
                    return dep;
                }
            }
            return null;
        }
    }
}
