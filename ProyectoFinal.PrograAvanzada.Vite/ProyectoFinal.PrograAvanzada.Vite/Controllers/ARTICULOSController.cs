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
    public class ARTICULOSController : Controller
    {
        private ProyectoProgra5Entities db = new ProyectoProgra5Entities();

        // GET: ARTICULOS
        public ActionResult Index()
        {
            var aRTICULOS = db.ARTICULOS.Include(a => a.CATEGORIA_ARTICULO);
            return View(aRTICULOS.ToList());
        }

        // GET: ARTICULOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            if (aRTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULOS);
        }

        // GET: ARTICULOS/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA");
            return View();
        }

        // POST: ARTICULOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_CATEGORIA,ESTADO,MARCA,MODELO,DESCRIPCION,FOTOS")] ARTICULOS aRTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.ARTICULOS.Add(aRTICULOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA", aRTICULOS.ID_CATEGORIA);
            return View(aRTICULOS);
        }

        // GET: ARTICULOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            if (aRTICULOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA", aRTICULOS.ID_CATEGORIA);
            return View(aRTICULOS);
        }

        // POST: ARTICULOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_CATEGORIA,ESTADO,MARCA,MODELO,DESCRIPCION,FOTOS")] ARTICULOS aRTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICULOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA", aRTICULOS.ID_CATEGORIA);
            return View(aRTICULOS);
        }

        // GET: ARTICULOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            if (aRTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULOS);
        }

        // POST: ARTICULOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            db.ARTICULOS.Remove(aRTICULOS);
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
