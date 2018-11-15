using AuthenticationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationMVC.Areas.Administrator.Controllers
{
    public class ManageRoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Administrator/ManageRole
        public ActionResult Index()
        {
            var model = db.Roles.AsEnumerable();
            return View(model);
        }
    }
}