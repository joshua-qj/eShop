using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShop.Web.Controllers {
    public class AuthenticationController:Controller {
        [Route ("/authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromQuery]string usr, [FromQuery]string pwd) {
            //model binding, user pwd
            if (usr == "admin"&&pwd=="admin") {
                var userClaims=new List<Claim>() {
                    new Claim(ClaimTypes.Name,usr),
                    new Claim(ClaimTypes.Email,"admin@eshop.com"),
                    new Claim(ClaimTypes.MobilePhone,"04444444")
                };
                var userIdentity=new ClaimsIdentity(userClaims,"eShop.CookieAuth"); //"eShop.CookieAuth" is .Cookie.Name 
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);//"eShop.CookieAuth" is Authentication schema 
            }
            return Redirect("/outstandingorders");
        }
 

    [Route ("/logout")]
    public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return Redirect("/outstandingorders");
        }
    }
}
