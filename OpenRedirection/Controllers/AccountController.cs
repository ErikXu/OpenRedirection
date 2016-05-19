using System.Web.Mvc;
using System.Web.Security;
using OpenRedirection.Models;

namespace OpenRedirection.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View(new LogOnModel());
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            //Your logon logic here.

            FormsAuthentication.SetAuthCookie(model.UserName, false);

            if (!string.IsNullOrEmpty(returnUrl)
                && Url.IsLocalUrl(returnUrl) //Comment out this code will cause open redirection 
                )
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogOn", "Account");
        }
    }
}