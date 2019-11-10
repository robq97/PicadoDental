using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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