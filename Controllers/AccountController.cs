using BookStoreVer4.Interfaces;
using BookStoreVer4.Models.Clients;
using BookStoreVer4.ModelView;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreVer4.Controllers
{
    public class AccountController : Controller
    {
        public readonly IClients clients;

        public AccountController(IClients clients)
        {
            this.clients = clients;
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginClient)
        {
            if (ModelState.IsValid)
            {
                Client client = clients.get().FirstOrDefault(i => i.email == loginClient.email && i.clientPassword == loginClient.password);
                if (client != null)
                {
                    await Authenticate(client);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Login", "Некорректные логин и(или) пароль");
            return View(loginClient);
        }

        private async Task Authenticate(Client autentifiateClient)
        {
            var claims = new List<Claim>();
            //создаем один claim
            if (autentifiateClient.clientRole != null)
            {

                claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, autentifiateClient.email));
                claims.Add(new Claim(ClaimTypes.Name, autentifiateClient.firstName));
                claims.Add(new Claim(ClaimTypes.Role, autentifiateClient.clientRole));
                        

            }
            
            else 
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, autentifiateClient.email));
                claims.Add(new Claim(ClaimTypes.Name, autentifiateClient.firstName));
                
            }

             //создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Client client = clients.get().FirstOrDefault(i => i.email == model.email);
                if (client == null)
                {
                    Client newClient = new Client
                    {
                        firstName = model.firstName,
                        lastName = model.lastName,
                        clientPassword = model.Password,
                        email = model.email,
                        phoneNumber = model.phoneNumber

                    };
                    clients.Create(newClient);
                    await Authenticate(newClient);

                    return RedirectToAction("Index", "Home");
                }
                else { ModelState.AddModelError("", "Некорректные логин и(или) пароль"); }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
