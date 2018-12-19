using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProyectoFinal.PrograAvanzada.Vite.Wcf.Logica.Especificacion
{
    public class ProyectoFinalEspecificacion
    {
         public Model.PERSONA Login(string usuario, string pass) {

            var laAccion = new Logica.Accion.ProyectoFinalAccion();
            var elResultado = laAccion.Login(usuario,pass);
            return elResultado;


        }


    }
}