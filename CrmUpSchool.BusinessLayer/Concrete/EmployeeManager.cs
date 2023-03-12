using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void TChangeEmployeeStatusToFalse(int id)
        {
            _employeeDal.ChangeEmployeeStatusToFalse(id);
        }

        public void TChangeEmployeeStatusToTrue(int id)
        {
            _employeeDal.ChangeEmployeeStatusToTrue(id);
        }

        public void TDelete(Employee t)
        {
            _employeeDal.Delete(t);
        }

        public Employee TGetByID(int id)
        {
            return _employeeDal.GetByID(id);
        }

        public List<Employee> TGetEmployeesByCategory()
        {
            return _employeeDal.GetEmployeesByCategory();
        }

        public List<Employee> TGetList()
        {
            return _employeeDal.GetList();
        }

        public void TInsert(Employee t)
        {
            _employeeDal.Insert(t);
        }

        public void TUpdate(Employee t)
        {
            _employeeDal.Update(t);
        }
    }
}
