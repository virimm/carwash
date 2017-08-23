using avtomoika.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace avtomoika.Controllers
{
    public class OrdersController : Controller
    {
        private CarWashContext db = new CarWashContext();
        private string[] states = new [] { "Новый", "В процессе", "Завершен" };
        private string[] boxes = new[] { "BOX-7", "BOX-17", "BOX-9", "BOX-11", "BOX-5", "BOX-2" };


        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPartial()
        {
            var orders = db.Orders
                .Include(ord => ord.Client).ToList();
            return PartialView("_Index", orders);
        }

        [HttpGet]
        public ActionResult CreateAjax()
        {
            ViewBag.Boxes = new SelectList(boxes, states[0]);
            ViewBag.State = new SelectList(states, states[0]);
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult CreateAjax(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Date = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("IndexPartial");
            }
            else
            {
                return PartialView();
            }
        }

        public ActionResult EditAjax(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Boxes = new SelectList(boxes);
            ViewBag.State = new SelectList(states);
            return PartialView("_Edit", order);
        }

        [HttpPost]
        public ActionResult EditAjax(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexPartial");
            }
            return PartialView("_Edit", order);
        }


    }
}