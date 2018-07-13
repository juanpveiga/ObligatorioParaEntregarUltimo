using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using obligTallerObjDominio;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FachadaRepositorio
{
    [Serializable]
    public class Repositorio
    {
        #region Atributos 
        private string rutaArchivo; //atributo que define la ruta 

        //atributos que determinan los objetos a serializar o deserealizar
        private CRol roles;
        private CUsuario usuarios;
        private CLugar lugares;
        private CObra obras;
        private CEmpleado empleados;
        
        private CRodaje rodajes;

        #endregion



        #region metodos

        public void serializar()
        {//permite serializar los objetos, es decir guardar los valores de los objetos en formato binario

            //declaro un objeto FileStream en modo creacion es decir siempre lo creo
            FileStream fs = new FileStream(rutaArchivo, FileMode.Create);

            //declaro un objeto BinaryFormatter para poder dar el formato binario a los datos de los objetos
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, this);//serializo los objetos dependiendo si la serialización es personalizada o no
            //va a ir a las clases que deseo serealizar al método GetObjectData

            fs.Close();//cierro el fileStream
        }

        public void deserializar()
        {
            //permite a partir de un archivo binario clonar en memoria los objetos
            //declaro un objeto FileStream que referencia al arhivo de serealizacion 
            //el modo del mismo es Open para poder obtener los datos
            FileStream fs = new FileStream(rutaArchivo, FileMode.Open);

            if (rutaArchivo.Count() > 0 && fs.ToString().Count() > 0)
            {

                //declaro un objeto binaryFormatter , el mismo lo precisamos para poder trabajar con los datos
                //ya que el formato de los datos guardados en el archivo serializado es binario
                BinaryFormatter bf = new BinaryFormatter();

                //asigno al repositorio los datos que surgen de la deserealización
                Repositorio rep = bf.Deserialize(fs) as Repositorio;

                fs.Close();//cierro el fileStream y por ende el archivo
            }
        }
        #endregion

        #region Constructor



        public Repositorio(string rutaArchivo)
        {

            this.rutaArchivo = rutaArchivo;
            this.roles = CRol.Instancia;
            this.usuarios = CUsuario.Instancia;
            this.lugares = CLugar.Instancia;
            this.empleados = CEmpleado.Instancia;
            this.obras = CObra.Instancia;
            this.rodajes = CRodaje.Instancia;

        }
        #endregion
       
    }
}