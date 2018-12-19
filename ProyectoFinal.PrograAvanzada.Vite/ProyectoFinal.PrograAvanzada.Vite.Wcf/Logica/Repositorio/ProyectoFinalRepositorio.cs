using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.PrograAvanzada.Vite.Wcf.Logica.Repositorio
{
    public class ProyectoFinalRepositorio
    {

        public Model.PERSONA Login(string usuario, string pass)
        {
            PrograAvanzada.Vite.Model.ProyectoProgra5Entities _contexto = new Model.ProyectoProgra5Entities();
            var elResultado = _contexto.PERSONA.FirstOrDefault(x=>x.USUARIO==usuario&&x.PASSWORD==pass);
            return elResultado;
        }


    }
}