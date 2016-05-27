using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    { 

        //
        // GET: /Derived /

        public void Index()
        {
            string controller = RouteData.Values["controller"].ToString();
            string action = RouteData.Values["action"].ToString();
            Response.Write(string.Format("Controller: {0}; Action: {1}", controller, action));
        }

        public ActionResult Redirect()
        {
            return new RedirectResult("/Derived/Index");
        }

    }
}
