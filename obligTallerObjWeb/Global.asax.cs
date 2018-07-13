using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using FachadaRepositorio;

namespace obligTallerObjWeb
{
    public class Global : System.Web.HttpApplication
    {
        private Fachada f = new Fachada();
        protected void Application_Start(object sender, EventArgs e)
        {
            //defino una variable llamada rutaArchivo que guarda la ruta en la cual se encuentra el archivo de serialización

            string rutaArchivo = HttpRuntime.AppDomainAppPath + @"Binario\serial.bin";
            //defino una variable llamada parametros que guarda la ruta en la cual se encuentra el archivo de parametros
            string parametros = HttpRuntime.AppDomainAppPath + @"Configuracion\parametros.txt";

            if (File.Exists(rutaArchivo))// si el archivo de serializacion existe 
            {
                Repositorio rep = new Repositorio(rutaArchivo);//instancio un nuevo repositorio
                rep.deserializar(); //llamo al metodo de deserializar de la clase repositorio
            }
            else
            {
                //si el archivo de serializacion no existe, cargo los datos de prueba
                //recordar que acá deben llamar a fachada 
                f.precargaDatos();
                if (File.Exists(parametros))//si el archivo de parametros existe
                {
                     f.obtenerFictoRodaje(parametros); //llamo al método obtenerPrecioBaseProceso en la clase Fachada
                }
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

            //este evento se ejecuta cuando se cierra la aplicacion 

            //instancio un nuevo repositorio pasando como parametro la ruta en la cual se va a encontrar el archivo
            //de serialización
            Repositorio rep = new Repositorio(HttpRuntime.AppDomainAppPath + @"Binario\serial.bin");

            rep.serializar(); //llamo al metodo para serializar los datos

            //llamo al método para guardar el precioBase actualizadao en el archivo de texto que guarda
            //los parametros
           // f.modificarPrecioBase(150);
            //f.guardarPrecioBase(HttpRuntime.AppDomainAppPath + @"Configuracion\parametros.txt");

        }
    }
}