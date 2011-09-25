using System;
using System.Web.Mvc;
using System.Web.Security;
using MembershipProviderSample.Models;
using MvcTurbine.MembershipProvider;

namespace MembershipProviderSample.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMembershipService membershipService;

        public AccountController(IMembershipService membershipService)
        {
            this.membershipService = membershipService;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (membershipService.ValidateUser(model.UserName, model.Password))
                {
                    membershipService.LogInAsUser(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            throw new Exception("Sorry, but this sample does not allow you to register.");
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            throw new Exception("Sorry, this sample does not allow you to change your password.");
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}