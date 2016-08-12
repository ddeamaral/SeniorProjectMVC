using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeniorProjectMVC.Models;

namespace SeniorProjectMVC.Controllers
{
    public class OrderController : Controller
    {
        private DataBass db = new DataBass();

        // GET: Order
        public ActionResult Index()
        {
            var orderHeaders = db.OrderHeaders.Include(o => o.ShippingMethod).Include(o => o.Status);
            return View(orderHeaders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderHeader orderHeader = db.OrderHeaders.Find(id);
            if (orderHeader == null)
            {
                return HttpNotFound();
            }
            return View(orderHeader);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.ShippingMethod_ID = new SelectList(db.ShippingMethods, "ShippingMethod_ID", "Name");
            ViewBag.Status_ID = new SelectList(db.Status, "Status_ID", "Name");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderHeader_ID,OrderNumber,Total,Status_ID,Subtotal,ShippingMethod_ID,DateCreated")] OrderHeader orderHeader)
        {
            if (ModelState.IsValid)
            {
                db.OrderHeaders.Add(orderHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShippingMethod_ID = new SelectList(db.ShippingMethods, "ShippingMethod_ID", "Name", orderHeader.ShippingMethod_ID);
            ViewBag.Status_ID = new SelectList(db.Status, "Status_ID", "Name", orderHeader.Status_ID);
            return View(orderHeader);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderHeader orderHeader = db.OrderHeaders.Find(id);
            if (orderHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShippingMethod_ID = new SelectList(db.ShippingMethods, "ShippingMethod_ID", "Name", orderHeader.ShippingMethod_ID);
            ViewBag.Status_ID = new SelectList(db.Status, "Status_ID", "Name", orderHeader.Status_ID);
            return View(orderHeader);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderHeader_ID,OrderNumber,Total,Status_ID,Subtotal,ShippingMethod_ID,DateCreated")] OrderHeader orderHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShippingMethod_ID = new SelectList(db.ShippingMethods, "ShippingMethod_ID", "Name", orderHeader.ShippingMethod_ID);
            ViewBag.Status_ID = new SelectList(db.Status, "Status_ID", "Name", orderHeader.Status_ID);
            return View(orderHeader);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderHeader orderHeader = db.OrderHeaders.Find(id);
            if (orderHeader == null)
            {
                return HttpNotFound();
            }
            return View(orderHeader);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderHeader orderHeader = db.OrderHeaders.Find(id);
            db.OrderHeaders.Remove(orderHeader);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
