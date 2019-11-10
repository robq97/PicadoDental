using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class AuthenticationController : Controller
    {

        public ActionResult LogIn()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("NewCustomer", "Customer");
            }
            return View();
        }

        /// <summary>
        /// Revisa que el admin este con una sesion iniciada
        /// </summary>
        /// <returns>Devuelve el HomePage Publico</returns>
        public ActionResult LogOut()
        {
            if (Session["username"] != null)
            {
                Session["username"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Denied()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Authentication(Admin login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        BostreamEntities1 db = new BostreamEntities1();
        //        List<Admin> adminList = db.Admins.ToList();

        //        var user = (from userlist in adminList
        //                    where userlist.username == login.username && userlist.password == login.password
        //                    select new
        //                    {
        //                        userlist.AdminId,
        //                        userlist.username
        //                    }).ToList();
        //        if (user.FirstOrDefault() != null)
        //        {
        //            Session["UserName"] = user.FirstOrDefault().username;
        //            Session["UserID"] = user.FirstOrDefault().AdminId;
        //            return RedirectToAction("NewCustomer", "Customer");
        //        }
        //        else
        //        {
        //            return RedirectToAction("LogIn", "Admin");
        //        }

        //    }
        //    return new EmptyResult();
        //}
    }
}