using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Server_Responsive_Image.Controllers
{
    public class HomeController : Controller
    {
         public ActionResult Index()
         {
             return RedirectToAction("GetResponsiveImages", "ResponsiveImages", new {src = "D.png"});
         }

    }
}