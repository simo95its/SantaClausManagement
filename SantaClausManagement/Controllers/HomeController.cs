using MongoDB.Bson;
using MongoDB.Driver;
using SantaClausManagement.Models;
using SantaClausManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SantaClausManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (IsUserLogged())
            {
                Database db = new Database();
                List<Toy> toysList = db.GetAllToys();

                if (IsAdmin())
                {
                    var ordersDetailedList = db.GetAllOrdersJoinedWithToyDetails();
                    return View(new IndexViewModel(IsAdmin(), toysList, ordersDetailedList));
                }
                else
                {
                    List<Order> ordersList = db.GetAllOrderSortedByOldestOne();
                    return View(new IndexViewModel(IsAdmin(), toysList, ordersList));
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        private bool IsUserLogged()
        {
            return (Session["Email"] != null && Session["Password"] != null) ? true : false;
        }

        private bool IsAdmin()
        {
            return (bool)Session["IsAdmin"];
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                Database db = new Database();

                string hash = model.Password
                    .FromUTF8StringToByteArray()
                    .ToSHA512()
                    .ToHexStringLowerCase();

                var userDocument = db.GetUser(model.Email, hash);
                if (userDocument != null)
                {
                    Session["Email"] = userDocument.Email;
                    Session["Password"] = userDocument.Password;
                    Session["ScreenName"] = userDocument.ScreenName;
                    Session["IsAdmin"] = userDocument.IsAdmin;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Error = "Invalid Login";
            return View();
        }



        public JsonResult Modal(string id)
        {
            if (Session["Email"] != null && Session["Password"] != null && (bool)Session["IsAdmin"] == false && id != null)
            {
                Database db = new Database();

                var order = db.GetOrder(id);

                return Json(new ModalViewModel(order), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new object(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}