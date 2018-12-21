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
    public class PERSONA_ENTREGANDO_CUSController : Controller
    {
        private ProyectoProgra5Entities db = new ProyectoProgra5Entities();

        // GET: PERSONA_ENTREGANDO_CUS
        public ActionResult Index()
        {
            var pERSONA_ENTREGANDO = db.PERSONA_ENTREGANDO.Include(p => p.ARTICULOS).Include(p => p.PERSONA);
            return View(pERSONA_ENTREGANDO.ToList());
        }

        // GET: PERSONA_ENTREGANDO_CUS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA_ENTREGANDO pERSONA_ENTREGANDO = db.PERSONA_ENTREGANDO.Find(id);
            if (pERSONA_ENTREGANDO == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_ENTREGANDO);
        }

        // GET: PERSONA_ENTREGANDO_CUS/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOS, "ID", "DESCRIPCION");
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO");
            return View();
        }

        // POST: PERSONA_ENTREGANDO_CUS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_PERSONA,ID_ARTICULO,FECHA_ENTREGA")] PERSONA_ENTREGANDO pERSONA_ENTREGANDO)
        {
            if (ModelState.IsValid)
            {
                db.PERSONA_ENTREGANDO.Add(pERSONA_ENTREGANDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOS, "ID", "ESTADO", pERSONA_ENTREGANDO.ID_ARTICULO);
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO", pERSONA_ENTREGANDO.ID_PERSONA);
            return View(pERSONA_ENTREGANDO);
        }

        // GET: PERSONA_ENTREGANDO_CUS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA_ENTREGANDO pERSONA_ENTREGANDO = db.PERSONA_ENTREGANDO.Find(id);
            if (pERSONA_ENTREGANDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOS, "ID", "ESTADO", pERSONA_ENTREGANDO.ID_ARTICULO);
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO", pERSONA_ENTREGANDO.ID_PERSONA);
            return View(pERSONA_ENTREGANDO);
        }

        // POST: PERSONA_ENTREGANDO_CUS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_PERSONA,ID_ARTICULO,FECHA_ENTREGA")] PERSONA_ENTREGANDO pERSONA_ENTREGANDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONA_ENTREGANDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTICULO = new SelectList(db.ARTICULOS, "ID", "ESTADO", pERSONA_ENTREGANDO.ID_ARTICULO);
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO", pERSONA_ENTREGANDO.ID_PERSONA);
            return View(pERSONA_ENTREGANDO);
        }

        // GET: PERSONA_ENTREGANDO_CUS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA_ENTREGANDO pERSONA_ENTREGANDO = db.PERSONA_ENTREGANDO.Find(id);
            if (pERSONA_ENTREGANDO == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_ENTREGANDO);
        }

        // POST: PERSONA_ENTREGANDO_CUS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONA_ENTREGANDO pERSONA_ENTREGANDO = db.PERSONA_ENTREGANDO.Find(id);
            db.PERSONA_ENTREGANDO.Remove(pERSONA_ENTREGANDO);
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
