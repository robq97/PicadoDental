using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicadoDental.Controllers
{
    public class InternalServerErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}