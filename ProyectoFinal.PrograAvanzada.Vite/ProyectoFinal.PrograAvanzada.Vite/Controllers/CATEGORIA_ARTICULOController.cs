using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.PrograAvanzada.Vite.Model;

namespace ProyectoFinal.PrograAvanzada.Vite.Controllers
{
    public class CATEGORIA_ARTICULOController : Controller
    {
        private ProyectoProgra5Entities db = new ProyectoProgra5Entities();

        // GET: CATEGORIA_ARTICULO
        public ActionResult Index()
        {
            return View(db.CATEGORIA_ARTICULO.ToList());
        }

        // GET: CATEGORIA_ARTICULO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_ARTICULO cATEGORIA_ARTICULO = db.CATEGORIA_ARTICULO.Find(id);
            if (cATEGORIA_ARTICULO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_ARTICULO);
        }

        // GET: CATEGORIA_ARTICULO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIA_ARTICULO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE_CATEGORIA,SUBCATEGORIA")] CATEGORIA_ARTICULO cATEGORIA_ARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIA_ARTICULO.Add(cATEGORIA_ARTICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIA_ARTICULO);
        }

        // GET: CATEGORIA_ARTICULO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_ARTICULO cATEGORIA_ARTICULO = db.CATEGORIA_ARTICULO.Find(id);
            if (cATEGORIA_ARTICULO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_ARTICULO);
        }

        // POST: CATEGORIA_ARTICULO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE_CATEGORIA,SUBCATEGORIA")] CATEGORIA_ARTICULO cATEGORIA_ARTICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIA_ARTICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIA_ARTICULO);
        }

        // GET: CATEGORIA_ARTICULO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_ARTICULO cATEGORIA_ARTICULO = db.CATEGORIA_ARTICULO.Find(id);
            if (cATEGORIA_ARTICULO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_ARTICULO);
        }

        // POST: CATEGORIA_ARTICULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIA_ARTICULO cATEGORIA_ARTICULO = db.CATEGORIA_ARTICULO.Find(id);
            db.CATEGORIA_ARTICULO.Remove(cATEGORIA_ARTICULO);
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
