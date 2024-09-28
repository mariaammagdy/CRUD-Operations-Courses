using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using STDem0.Models;
using STDem0.Repository;
using System.Security.Claims;

namespace STDem0.Controllers
{
    public class UserController : Controller
    {
        IUserRepo userrep;
        public UserController(IUserRepo _userRep)
        {
            userrep = _userRep;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
           var u = userrep.GetUserByCredentials(model.Username, model.Password);
            if (u != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , u.Username),
                    new Claim(ClaimTypes.Email , u.Email),
                    new Claim(ClaimTypes.Role , "Student")
                };
                var ClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var ClaimPrincipal = new ClaimsPrincipal(ClaimIdentity);
                await HttpContext.SignInAsync(ClaimPrincipal);
                return RedirectToAction("Index", "Department");

            }
            else
            {
                ModelState.AddModelError("", "Username or Password incorrect");
            }
          /*   if (model.Username =="mariam" && model.Password=="123456")
            {
             Claim c1 = new Claim(ClaimTypes.Name, model.Username);
                Claim c2 = new Claim(ClaimTypes.Email, $"{model.Username}@gmail.com");
                Claim c3 = new Claim(ClaimTypes.Role ,"Student");
                ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    ci.AddClaim(c1);
                ci.AddClaim(c2);
                ci.AddClaim(c3);
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
               await HttpContext.SignInAsync(cp);
                return RedirectToAction("Index","department");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password incorrect");

                
            }*/
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            userrep.Add(user);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "department");
        }
    }
}
