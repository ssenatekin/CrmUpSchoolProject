using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.BusinessLayer.ValidationRules;
using CrmUpSchool.EntityLayer.Concrete;
using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICategoryService _categoryService;

        public EmployeeController(IEmployeeService employeeService, ICategoryService categoryService)
        {
            _employeeService = employeeService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.TGetEmployeesByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee() 
        {
            List <SelectListItem> categoryValues=(from x in _categoryService.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.v = categoryValues; //dropdowna taşımak için viewbag
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            EmployeeValidator validationRules = new EmployeeValidator();
            ValidationResult result = validationRules.Validate(employee);
            if (result.IsValid)
            {
                _employeeService.TInsert(employee);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    //modelstate-- modelden gelen durumları göstermek için kullanıyoruz
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteEmployee(int id)
        {
            var values=_employeeService.TGetByID(id);
            _employeeService.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            _employeeService.TChangeEmployeeStatusToFalse(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToTrue(int id)
        {
            _employeeService.TChangeEmployeeStatusToTrue(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var values=_employeeService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var values = _employeeService.TGetByID(employee.EmployeeID);
            employee.EmployeeStatus = values.EmployeeStatus;
            _employeeService.TUpdate(employee);
            return RedirectToAction("Index");
        }

    }
}
