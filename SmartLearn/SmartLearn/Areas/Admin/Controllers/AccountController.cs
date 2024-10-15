using SmartLearn.Areas.Admin.Models;
using SmartLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartLearn.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(LoginModel loginInfo)
        {
            var adminService = new AdminService();
            var isLoggedIn = adminService.Login(loginInfo.Email, loginInfo.Password);
            if (isLoggedIn)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                loginInfo.Message = "Email or Password Incorrect!!";
                return View(loginInfo);
            }

        }
    }
}