using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class Obra : ISerializable
    {
        #region Atributos
        private string nombre;
        private DateTime fechaIni;
        private DateTime fechaPromFin;
        private double costoBase;
        private bool baja;
        #endregion

        #region propiedades
        public double CostoBase
        {
            get
            {
                return this.costoBase;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public bool Baja
        {
            get
            {
                return this.baja;
            }
        }

        public string FechaIniGrilla
        {
            get { return this.fechaIni.ToShortDateString(); }
        }

        public string FechaPromFinGrilla
        {
            get { return this.fechaPromFin.ToShortDateString(); }
        }

        #endregion



        #region Constructor
        public Obra(string nombre, DateTime fechaIni, DateTime fechaPromFin, double costoBase)
        {

            this.nombre = nombre;
            this.fechaIni = fechaIni;
            this.fechaPromFin = fechaPromFin;
            this.costoBase = costoBase;
            this.baja = false;
        }

        #endregion

        #region Metodos

        public bool darBaja()
        {
            return this.baja = true;

        }

        public void editarObra(string nombre, DateTime fechaIni, DateTime fechaPromFin, double costBase)
        {
            
                this.nombre = nombre;
                this.fechaIni = fechaIni;
                this.fechaPromFin = fechaPromFin;
                this.costoBase = costBase;
                
        }

        public bool buscarAtrasadas()
        {
            bool atrasadas = false;

            if(this.fechaPromFin.CompareTo(DateTime.Today)== -1)
            {
                atrasadas = true;
            }
            return atrasadas;
        }


        public override string ToString()
        {
            return this.nombre + " , " + this.fechaPromFin + " .";
        }

        
        #endregion

        
        #region metodosSerilaizacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {


            info.AddValue("nombre", this.nombre, typeof(string));
            info.AddValue("fechaIni", this.fechaIni, typeof(DateTime));
            info.AddValue("fechaPromFin", this.fechaPromFin, typeof(DateTime));
            info.AddValue("costoBase", this.costoBase, typeof(double));
            info.AddValue("baja", this.baja, typeof(bool));


        }
        public Obra(SerializationInfo info, StreamingContext context)
        {


            this.nombre = (string)info.GetValue("nombre", typeof(string));
            this.fechaIni = (DateTime)info.GetValue("fechaIni", typeof(DateTime));
            this.fechaPromFin = (DateTime)info.GetValue("fechaPromFin", typeof(DateTime));
            this.costoBase = (double)info.GetValue("costoBase", typeof(double));
            this.baja = (bool)info.GetValue("baja", typeof(bool));
        }
            #endregion

        }
    }
