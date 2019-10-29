using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;
using Wired.Data.Repository.Contracts;
using Wired.Models.Entities;
using Wired.Models.ViewModels;

namespace Wired.Controllers
{
    public class AccountController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IAdministratorRepository _admRepository;

        public AccountController(ICustomerRepository customerRepository, IAdministratorRepository admRepository)
        {
            _customerRepository = customerRepository;
            _admRepository = admRepository;
        }

        const string userName = "_userName";
        const string userEmail = "_userEmail";
        const string userId = "_userId";
        const string userProfile = "_userProfile";

        public IActionResult Index()
        {
            return View("Index");
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(userId);
            HttpContext.Session.Remove(userName);
            HttpContext.Session.Remove(userEmail);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel formUser)
        {
            ViewBag.Login = true;

            if (ModelState.IsValid)
            {
                try
                {
                    User user = await GetUser(formUser);

                    if (user != null)
                    {
                        HttpContext.Session.SetString(userEmail, user.Email);
                        HttpContext.Session.SetString(userName, user.Name);
                        HttpContext.Session.SetInt32(userId, user.Id);

                        ViewData["username"] = user.Name;
                        ViewData["useremail"] = user.Email;
                        ViewData["id"] = user.Id;

                        if (user is Administrator)
                        {
                            ViewData["UserProfile"] = "Admin";
                            HttpContext.Session.SetString(userProfile, "Admin");
                            return View("~/Views/Administrator/Index.cshtml");
                        }

                        ViewData["UserProfile"] = "Customer";
                        HttpContext.Session.SetString(userProfile, "Customer");
                        return View("~/Views/Customers/Index.cshtml", user);
                    }

                    ViewBag.error = "Login inválido. Verifique os dados.";
                    return View("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View("Error");
                }
            }

            return View("Index");
        }

        private async Task<User> GetUser(LoginViewModel formUser)
        {
            User user = null;
            user = await _customerRepository
                       .GetFirstAsync
                       (
                           e => e.Email.Equals(formUser.Email) &&
                           e.Password.Equals(PasswordManager.CalculateSha1(formUser.Password, Encoding.Default))
                       );

            if (user == null)
            {
                var userAdm = await _admRepository
                    .GetFirstAsync(e => e.Email.Equals(formUser.Email));

                if (userAdm != null)
                    user = formUser.Password.Equals(PasswordManager.GetAdmPassword()) ? userAdm : null;
            }

            return user;
        }
    }
}
