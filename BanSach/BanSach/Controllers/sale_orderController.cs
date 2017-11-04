using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanSach.Models;

namespace BanSach.Controllers
{
    public class sale_orderController : Controller
    {
        private Model1 db = new Model1();

        // GET: sale_order
        public ActionResult Index()
        {
            var sale_order = db.sale_order.Include(s => s.agency);
            return View(sale_order.ToList());
        }

        // GET: sale_order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale_order sale_order = db.sale_order.Find(id);
            if (sale_order == null)
            {
                return HttpNotFound();
            }
            return View(sale_order);
        }

        // GET: sale_order/Create
        public ActionResult Create()
        {
            ViewBag.fk_agency = new SelectList(db.agencies, "agency_id", "agency_name");
            return View();
        }

        // POST: sale_order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sale_order_id,fk_agency,sale_order_created_at,sale_order_total_money,sale_order_status")] sale_order sale_order)
        {
            if (ModelState.IsValid)
            {
                db.sale_order.Add(sale_order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_agency = new SelectList(db.agencies, "agency_id", "agency_name", sale_order.fk_agency);
            return View(sale_order);
        }

        // GET: sale_order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale_order sale_order = db.sale_order.Find(id);
            if (sale_order == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_agency = new SelectList(db.agencies, "agency_id", "agency_name", sale_order.fk_agency);
            return View(sale_order);
        }

        // POST: sale_order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sale_order_id,fk_agency,sale_order_created_at,sale_order_total_money,sale_order_status")] sale_order sale_order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale_order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_agency = new SelectList(db.agencies, "agency_id", "agency_name", sale_order.fk_agency);
            return View(sale_order);
        }

        // GET: sale_order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale_order sale_order = db.sale_order.Find(id);
            if (sale_order == null)
            {
                return HttpNotFound();
            }
            return View(sale_order);
        }

        // POST: sale_order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sale_order sale_order = db.sale_order.Find(id);
            db.sale_order.Remove(sale_order);
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
