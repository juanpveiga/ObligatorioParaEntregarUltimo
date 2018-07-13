using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class LocacionExt : Rodaje,ISerializable
    {
        #region Atributos
        private string locacion;
        #endregion

        #region propiedades
        public string Locacion
        {
            get
            {
                return this.locacion;
            }
        }
        #endregion

        #region Constructor
        public LocacionExt(int nroIden, Lugar lugar, DateTime fechaInicio, int hora, int duracion, Obra obra,
            Usuario usuario, string locacion) : base(nroIden, lugar, fechaInicio, hora, duracion, obra, usuario)
        {
            this.locacion = locacion;
           

        }
        #endregion

        #region Metodo

        
        public override double calcularCosto()
        {
            double costo = 0;

            if(locacion.ToLower() == "exterior")
            {
                costo = base.calcularCostoParcial() + base.calcularCostoParcial() * 0.10;
            }
            if( locacion.ToLower() == "interior")
            {
                costo = base.calcularCostoParcial() + base.calcularCostoParcial() * 0.05;
            }

            return costo;
           
        }
        #endregion

        #region MetodoSerializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("nroIden", this.NroIden, typeof(int));
            info.AddValue("lugar", this.Lugar, typeof(Lugar));
            info.AddValue("fechaInicio", this.FechaInicio, typeof(DateTime));
            info.AddValue("fechaFin", this.FechaFin, typeof(DateTime));
            info.AddValue("hora", this.Hora, typeof(int));
            info.AddValue("duracion", this.Duracion, typeof(int));
            info.AddValue("empleadosRod", this.EmpleadosRod, typeof(List<EmpEnRod>));
            info.AddValue("realizado", this.Realizado, typeof(bool));
            info.AddValue("obra", this.Obra, typeof(Obra));
            info.AddValue("usuario", this.Usuario, typeof(Usuario));
            info.AddValue("baja", this.Baja, typeof(bool));
            info.AddValue("locacion", this.locacion, typeof(string));



        }
        public LocacionExt(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.NroIden = (int)info.GetValue("nroIden", typeof(int));
            this.Lugar = (Lugar)info.GetValue("lugar", typeof(Lugar));
            this.FechaInicio = (DateTime)info.GetValue("fechaInicio", typeof(DateTime));
            this.FechaFin = (DateTime)info.GetValue("fechaFin", typeof(DateTime));
            this.Hora = (int)info.GetValue("hora", typeof(int));
            this.Duracion = (int)info.GetValue("duracion", typeof(int));
            this.EmpleadosRod = (List<EmpEnRod>)info.GetValue("empleadosRod", typeof(List<EmpEnRod>));
            this.Realizado = (bool)info.GetValue("realizado", typeof(bool));
            this.Obra = (Obra)info.GetValue("obra", typeof(Obra));
            this.Usuario = (Usuario)info.GetValue("usuario", typeof(Usuario));
            this.Baja = (bool)info.GetValue("baja", typeof(bool));
            this.locacion = (string)info.GetValue("locacion", typeof(string));







        }
        #endregion
    }
}
