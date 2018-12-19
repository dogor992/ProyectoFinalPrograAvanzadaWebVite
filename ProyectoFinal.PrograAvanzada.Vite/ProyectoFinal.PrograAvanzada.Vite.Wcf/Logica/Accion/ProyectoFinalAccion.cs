using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.PrograAvanzada.Vite.Wcf.Logica.Accion
{
    public class ProyectoFinalAccion
    {

        public Model.PERSONA Login(string usuario, string pass)
        {

            var elRepositorio = new Logica.Repositorio.ProyectoFinalRepositorio();
            var elResultado = elRepositorio.Login(usuario, pass);
            return elResultado;

        }
    }
}