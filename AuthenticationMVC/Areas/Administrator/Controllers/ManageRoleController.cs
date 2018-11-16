using AuthenticationMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationMVC.Areas.Administrator.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManageRoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Administrator/ManageRole
        public ActionResult Index()
        {
            var model = db.Roles.AsEnumerable();
            //foreach (var item in model)
            //{
            //    item.
            //}
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    await db.SaveChangesAsync();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(role);
            }

        }
        public ActionResult Delete(string id)
        {
            var model = db.Roles.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole model = null;
            try
            {
                model = db.Roles.Find(id);
                db.Roles.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}