using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class CObra : ISerializable
    {
        #region Atributos
        private static CObra instancia;
        private List<Obra> obras = new List<Obra>();
        #endregion

        #region Propiedades
        public static CObra Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new CObra();
                }
                return instancia;
            }
           
        }

        #endregion

        #region Constructor Singleton
        private CObra()
        {

        }
        #endregion

        #region Metodos

        public bool altaObra(string nombre, DateTime fechaIni, DateTime fechaPromFin, double costoBase)
        
            {
            bool resultado = false;
            int totalObras = obras.Count();
            if (this.buscarObra(nombre) == null && fechaIni <= DateTime.Today && fechaPromFin >= fechaIni && costoBase >= 0)
            {
                obras.Add(new Obra(nombre, fechaIni, fechaPromFin, costoBase));
                if (totalObras < obras.Count)
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        public bool bajaObra(string nombreObra)
        {
            bool baja = false;
            Obra o = buscarObra(nombreObra);
            if (o != null && nombreObra != "" && o.Baja == false)
            {
                baja = o.darBaja();

            }
            return baja;
        }

         public bool editarObra(string nombre, string nombreNuevo, DateTime fechaIni, DateTime fechaPromFin, double costoBase)
        {
            bool editado = false;
            Obra o = buscarObra(nombre);
            if(o != null && nombre != "" && nombreNuevo != "" && fechaIni < fechaPromFin && costoBase >= 0 && o.Baja == false)
            {
               o.editarObra(nombreNuevo,fechaIni,fechaPromFin,costoBase);
                editado = true;
            }
            return editado;
        }

        public Obra buscarObra (string nombre)
        {
            Obra o = null;
            int i = 0;

            while (i < obras.Count && o == null)
            {
                if (obras[i].Nombre == nombre)
                {
                    o = obras[i];
                }
                i++;
            }
            return o;
        }

         
        public List<Obra> obrasAtrasadas()
        {
            List<Obra> obrasAtrasadas = new List<Obra>();

            foreach(Obra o  in obras)
            {
                if (o.buscarAtrasadas())

                    obrasAtrasadas.Add(o);
            }
            return obrasAtrasadas;
        }

        public List<Obra> buscarObrasActivas()
        {
            List<Obra> obrasActivas = new List<Obra>();

            foreach(Obra o in this.obras)
            {
                if (!o.Baja)
                {
                    obrasActivas.Add(o);
                }
            }

            return obrasActivas;
        }

        #endregion

        #region metodos Serializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("obras", this.obras, typeof(List<Lugar>));


        }
        public CObra(SerializationInfo info, StreamingContext context)
        {


            this.obras = (List<Obra>)info.GetValue("obras", typeof(List<Obra>));
            CObra.instancia = this;
        }
        #endregion
    }
}
