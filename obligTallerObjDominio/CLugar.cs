using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class CLugar : ISerializable
    {
        #region Atributos
        private static CLugar instancia;
        private List<Lugar> lugares = new List<Lugar>();
        #endregion

        #region Propiedades
        public static CLugar Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new CLugar();
                }
                return instancia;
            }
        }

        public List<Lugar> Lugares
        {
            get { return this.lugares; }
        }
        #endregion

        #region Constructor Singeton
        private CLugar()
        {

        }
        #endregion

        #region Metodos
        public bool altaLugar(string nombre, string direccion)
        {
            bool alta = false;
            Lugar l = buscarLugar(nombre);
            int totalLugares  = lugares.Count();

            if (l == null && nombre != "" && direccion != "")
            {
                lugares.Add (new Lugar(nombre, direccion));
                if(totalLugares < lugares.Count)
                {
                    alta = true;
                }
            }

            return alta;
        }

        public bool bajaLugar(string nombre)
        {
            bool baja = false;
            Lugar l = buscarLugar(nombre);

            if(l != null && nombre != "" && !l.Baja)
            {
                baja = l.bajaLugar(); 
            }

            return baja;
        }

        /*public string bajaLugar(string nombre)
        {
            string salida = "";
            Lugar l = buscarLugar(nombre);
            if(l != null)
            {
              if(CRodaje.Instancia.buscarLugarEnRodaje(l)) 
                {
                    salida = " No se puede dar de baja,esta asignado en un rodaje.";
                }
                else
                {
                   if(l.bajaLugar())
                    {
                        salida = " Se dio de baja correctamente.";
                    }
                }
              
            }
            return salida;
        }*/

        public bool editarLugar(string nombre,string nombreNuevo, string direccion)
        {
            bool editado = false;
            Lugar l = buscarLugar(nombre);
            if (l != null && nombre != "" && nombreNuevo != "" && direccion != "" && !l.Baja)
            {
                l.editarLugar(nombreNuevo, direccion);
                editado = true;
           }
            return editado;
        }

        public Lugar buscarLugar (string nombre)
        {
            Lugar l = null;
            int i = 0;
            while (i < lugares.Count && l == null)
            {
                if (lugares[i].NomLugar == nombre)
                {
                    l = lugares[i];
                }
                i++;
            }
            return l;
        }
        #endregion

        #region MetodosSerializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("lugares", this.lugares, typeof(List<Lugar>));


        }
        public CLugar(SerializationInfo info, StreamingContext context)
        {


            this.lugares = (List<Lugar>)info.GetValue("lugares", typeof(List<Lugar>));
            CLugar.instancia = this;


        }
    }
    #endregion

}

