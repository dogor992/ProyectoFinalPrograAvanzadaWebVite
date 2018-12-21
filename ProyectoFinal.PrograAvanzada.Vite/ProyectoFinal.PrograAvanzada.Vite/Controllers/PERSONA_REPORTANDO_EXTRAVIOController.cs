using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.PrograAvanzada.Vite.Model;

namespace ProyectoFinal.PrograAvanzada.Vite.Controllers
{
    public class PERSONA_REPORTANDO_EXTRAVIOController : Controller
    {
        private ProyectoProgra5Entities db = new ProyectoProgra5Entities();

        // GET: PERSONA_REPORTANDO_EXTRAVIO
        public ActionResult Index()
        {
            var pERSONA_REPORTANDO_EXTRAVIO = db.PERSONA_REPORTANDO_EXTRAVIO.Include(p => p.CATEGORIA_ARTICULO).Include(p => p.PERSONA);
            return View(pERSONA_REPORTANDO_EXTRAVIO.ToList());
        }

        // GET: PERSONA_REPORTANDO_EXTRAVIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA_REPORTANDO_EXTRAVIO pERSONA_REPORTANDO_EXTRAVIO = db.PERSONA_REPORTANDO_EXTRAVIO.Find(id);
            if (pERSONA_REPORTANDO_EXTRAVIO == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_REPORTANDO_EXTRAVIO);
        }

        // GET: PERSONA_REPORTANDO_EXTRAVIO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA");
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO");
            return View();
        }

        // POST: PERSONA_REPORTANDO_EXTRAVIO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_PERSONA,ID_CATEGORIA,FECHA_REPORTE")] PERSONA_REPORTANDO_EXTRAVIO pERSONA_REPORTANDO_EXTRAVIO)
        {
            if (ModelState.IsValid)
            {
                db.PERSONA_REPORTANDO_EXTRAVIO.Add(pERSONA_REPORTANDO_EXTRAVIO);
                db.SaveChanges();
                var usuario = db.PERSONA.Find(pERSONA_REPORTANDO_EXTRAVIO.ID_PERSONA);
                var articulo = db.ARTICULOS.Where(x=> x.ID_CATEGORIA==pERSONA_REPORTANDO_EXTRAVIO.ID_CATEGORIA);
                if (articulo != null)
                {
                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(usuario.EMAIL));
                    email.From = new MailAddress("dogor992@gmail.com");
                    email.Subject = "Oficina custodias Asunto ( " + DateTime.Now.ToString("dd/mm/yyy hh:mm:ss") + ")";
                    email.Body = "Se encontro un articulo con la categoria que ingreso, por favor ir a la oficina de custodia";
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.Normal;

                    //smtp
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("dogor992@gmail.com", "kebolebe");
                    string output = null;

                    //enviar email
                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "correo electronico fue enviado satisfactoriamente";
                    }
                    catch (Exception ex)
                    {

                        output = "error enviado el correo electronico" + ex.Message;
                    }
                }
                else {
                    MailMessage email = new MailMessage();
                    email.To.Add(new MailAddress(usuario.EMAIL));
                    email.From = new MailAddress("dogor992@gmail.com");
                    email.Subject = "Oficina custodias Asunto ( " + DateTime.Now.ToString("dd/mm/yyy hh:mm:ss") + ")";
                    email.Body = "No se encontro ningun articulo relacionado a su reporte, si ingresa uno le informaremos";
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.Normal;

                    //smtp
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("dogor992@gmail.com", "kebolebe");
                    string output = null;

                    //enviar email
                    try
                    {
                        smtp.Send(email);
                        email.Dispose();
                        output = "correo electronico fue enviado satisfactoriamente";
                    }
                    catch (Exception ex)
                    {

                        output = "error enviado el correo electronico" + ex.Message;
                    }

                }
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA", pERSONA_REPORTANDO_EXTRAVIO.ID_CATEGORIA);
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO", pERSONA_REPORTANDO_EXTRAVIO.ID_PERSONA);
            return View(pERSONA_REPORTANDO_EXTRAVIO);
        }

        // GET: PERSONA_REPORTANDO_EXTRAVIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA_REPORTANDO_EXTRAVIO pERSONA_REPORTANDO_EXTRAVIO = db.PERSONA_REPORTANDO_EXTRAVIO.Find(id);
            if (pERSONA_REPORTANDO_EXTRAVIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA", pERSONA_REPORTANDO_EXTRAVIO.ID_CATEGORIA);
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO", pERSONA_REPORTANDO_EXTRAVIO.ID_PERSONA);
            return View(pERSONA_REPORTANDO_EXTRAVIO);
        }

        // POST: PERSONA_REPORTANDO_EXTRAVIO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_PERSONA,ID_CATEGORIA,FECHA_REPORTE")] PERSONA_REPORTANDO_EXTRAVIO pERSONA_REPORTANDO_EXTRAVIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONA_REPORTANDO_EXTRAVIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.CATEGORIA_ARTICULO, "ID", "NOMBRE_CATEGORIA", pERSONA_REPORTANDO_EXTRAVIO.ID_CATEGORIA);
            ViewBag.ID_PERSONA = new SelectList(db.PERSONA, "ID", "NOMBRE_COMPLETO", pERSONA_REPORTANDO_EXTRAVIO.ID_PERSONA);
            return View(pERSONA_REPORTANDO_EXTRAVIO);
        }

        // GET: PERSONA_REPORTANDO_EXTRAVIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA_REPORTANDO_EXTRAVIO pERSONA_REPORTANDO_EXTRAVIO = db.PERSONA_REPORTANDO_EXTRAVIO.Find(id);
            if (pERSONA_REPORTANDO_EXTRAVIO == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_REPORTANDO_EXTRAVIO);
        }

        // POST: PERSONA_REPORTANDO_EXTRAVIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONA_REPORTANDO_EXTRAVIO pERSONA_REPORTANDO_EXTRAVIO = db.PERSONA_REPORTANDO_EXTRAVIO.Find(id);
            db.PERSONA_REPORTANDO_EXTRAVIO.Remove(pERSONA_REPORTANDO_EXTRAVIO);
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
