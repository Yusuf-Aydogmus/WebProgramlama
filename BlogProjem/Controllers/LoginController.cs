using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProjem.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
     

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> Index(Writer param)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == param.WriterMail && x.WriterPassword == param.WriterPassword);
            if (datavalue != null)
            { //cliam-->Rollerin dışında kullanıcı hakkında bilgi tutmamızı ve bu bilgilere göre yetkilendirme yapmamızı sağlayan yapılardır.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,param.WriterMail)

                };

                var userIdentity = new ClaimsIdentity(claims, "a");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }

    }
}
