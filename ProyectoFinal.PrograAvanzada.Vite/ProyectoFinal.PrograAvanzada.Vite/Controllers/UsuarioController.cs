using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.PrograAvanzada.Vite.Wcf;

namespace ProyectoFinal.PrograAvanzada.Vite.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validar(string user, string password)
        {
            var elServicio = new ProyectoFinal.PrograAvanzada.Vite.Wcf.Logica.Especificacion.ProyectoFinalEspecificacion();
            Model.PERSONA elResultado = elServicio.Login(user, password);
            if (elResultado != null)
            {
                if (elResultado.ROL.Equals("Admin"))
                {
                    return RedirectToAction("Adminis", "Adminis");
                }
                else if (elResultado.ROL.Equals("Custodia"))
                {
                    return RedirectToAction("Custodia", "Custodia");
                }
                else if (elResultado.ROL.Equals("Invitado"))
                {
                    ViewBag.Correo =elResultado.EMAIL;
                    return RedirectToAction("Invitado", "Invitado");
                }
                else
                {
                    return RedirectToAction("NoHallado", "Usuario");
                }
            }
            else {
                return RedirectToAction("NoHallado", "Usuario");
            }
        }

        public ActionResult NoHallado()
        {
            ViewBag.Error = "No se encontro usuario indicado";
            return View();
        }
    }
}