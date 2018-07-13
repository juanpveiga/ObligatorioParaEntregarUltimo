using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class Estudio : Rodaje,ISerializable

    {
        #region Atributos
        private string set;
        private static double ficto;
        #endregion

        #region Propiedades
        public static double Ficto
        {
            set
            {
                Estudio.ficto = value;
            }
        }
        #endregion

        #region Constructor
        public Estudio(int nroIden, Lugar lugar, DateTime fechaInicio, int hora, int duracion, Obra obra,
            Usuario usuario, string set) : base(nroIden, lugar, fechaInicio,hora, duracion, obra, usuario)
        {
            this.set = set;
        }
        #endregion

        #region Metodo

        public override double calcularCosto()
        {
            return base.calcularCostoParcial() + Estudio.ficto;
        }

        #endregion

        #region MetodoSerilaizacion

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
            info.AddValue("set", this.set, typeof(string));
            info.AddValue("ficto", Estudio.ficto, typeof(double));

        }
        public Estudio(SerializationInfo info, StreamingContext context) : base(info, context)
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
            this.set = (string)info.GetValue("set", typeof(string));
            Estudio.ficto = (double)info.GetValue("ficto", typeof(double));

        }
        #endregion
    }
}
