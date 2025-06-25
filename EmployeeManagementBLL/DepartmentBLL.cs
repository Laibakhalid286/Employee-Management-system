using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementDAL;
using DTOdepartment;
using System.Runtime.Intrinsics.Arm;
using DTOemployee;

namespace EmployeeManagementBLL
{
    public class DepartmentBLL
    {
        DepartmentDAL depDAL = new DepartmentDAL();
        public bool CreateDepartment(DTOdep department)
        {
            List<DTOdep> departments = depDAL.GetAll();

            foreach(DTOdep dep in departments)
            {
                if (dep.Id == department.Id)
                {
                    Console.WriteLine("This is a duplicate ID");
                    return false;
                }

                if (dep.Name.ToLower() == department.Name.ToLower())
                {
                    Console.WriteLine("The is a duplicate name");
                    return false;
                }
            }
            depDAL.Save(department);
            return true;
        }

        public bool UpdateDepartment(DTOdep department)
        {
            DTOdep depExists = depDAL.GetdepbyID(department.Id);
            if (depExists == null)
            {
                Console.WriteLine("The department does not exist");
                return false;
            }

            depExists.Name = department.Name;
            depExists.Description = department.Description;

            return depDAL.Update(depExists);
        }

        public bool DeleteDepartment(int id)
        {
            bool exists = false;
            List<DTOdep> departments = depDAL.GetAll();
            foreach (DTOdep dep in departments)
            {
                if (dep.Id == id)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                Console.WriteLine("Department does not exist.");
                return false;
            }

            return depDAL.Delete(id);
        }
        public void Save(DTOdep dep)
        {
            DepartmentDAL depDal = new DepartmentDAL();
            depDal.Save(dep);
        }

        public List<DTOdep> GetAll()
        {
            DepartmentDAL depDal = new DepartmentDAL();
            return depDal.GetAll();
        }

    }
}
