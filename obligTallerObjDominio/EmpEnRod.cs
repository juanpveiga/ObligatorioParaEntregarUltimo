using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class EmpEnRod : ISerializable

    {
        #region Atributos
        private Empleado empleado;
        private int cantHoras;
        #endregion

        #region Constructor
        public EmpEnRod(Empleado empleado, int cantHoras)
        {
            this.empleado = empleado;
            this.cantHoras = cantHoras;
        }
        #endregion

        #region Propiedades
        public string NomEmp
        {
            get { return this.empleado.Nombre; }
        }

        public string ApEmp
        {
            get { return this.empleado.Apellido; }
        }

        public string RolEmp
        {
            get { return this.empleado.NomRol; }
        }

        public int CantHoras
        {
            get { return this.cantHoras; }
        }
        #endregion

        #region Metodos
        public double calcularSalario()
        {
            double salario = 0;

            salario = this.empleado.calcularValorHora() * this.cantHoras;

            return salario;
        }
        #endregion

        #region MetodosSerializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("empleado", this.empleado, typeof(Empleado));
            info.AddValue("cantHoras", this.cantHoras, typeof(int));



        }
        public EmpEnRod(SerializationInfo info, StreamingContext context)
        {


            this.empleado = (Empleado)info.GetValue("empleado", typeof(Empleado));
            this.cantHoras = (int)info.GetValue("cantHoras", typeof(int));
        }
        #endregion
    }
}
