using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationLab.Controllers
{
    //[AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            const string Issuer = "https://contoso.com";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "salim", ClaimValueTypes.String, Issuer));
            claims.Add(new Claim(ClaimTypes.Role, "User", ClaimValueTypes.String, Issuer));
            // Add second claim
            claims.Add(new Claim("EmployeeId", "123", ClaimValueTypes.String, Issuer));
            claims.Add(new Claim(ClaimTypes.DateOfBirth, "1999-06-08", ClaimValueTypes.Date));
           

            //claims.Add(new Claim(ClaimTypes.Name, "salim", ClaimValueTypes.String, Issuer));
            //claims.Add(new Claim(ClaimTypes.Role, "ProjectLead", ClaimValueTypes.String, Issuer));

            //claims.Add(new Claim(ClaimTypes.Name, "salim", ClaimValueTypes.String, Issuer));
            //claims.Add(new Claim(ClaimTypes.Role, "Calibrator", ClaimValueTypes.String, Issuer));

            //claims.Add(new Claim(ClaimTypes.Name, "salim", ClaimValueTypes.String, Issuer));
            //claims.Add(new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String, Issuer));

            var userIdentity = new ClaimsIdentity("SuperSecureLogin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
