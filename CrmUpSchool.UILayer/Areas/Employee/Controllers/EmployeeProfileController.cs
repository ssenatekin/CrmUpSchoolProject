using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //findbynameasync deki name kullanıcı adının namei
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.PhoneNumber = values.PhoneNumber;
            userEditViewModel.Email= values.Email;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.Image != null)
            {
                //bulunduğumuz konumu alıyor
                var resource=Directory.GetCurrentDirectory();
                var extension=Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImages/" + imageName;
                //create dosya oluşturma modu
                var stream= new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageURL= imageName;
            }
            user.Name= p.Name;
            user.Surname = p.Surname;
            user.PhoneNumber=p.PhoneNumber;
            user.Email= p.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result=await _userManager.UpdateAsync(user);
            //resultta değer varsa
            if(result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
