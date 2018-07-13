using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class Empleado : ISerializable
    {
        #region Atributos
        private int nroEmpleado;
        private string nombre;
        private string apellido;
        private Rol rol;
        private bool baja;
        #endregion

        #region Propiedades
        public int NroEmpleado
        {
            get { return this.nroEmpleado; }
        }

        public bool Baja
        {
            get { return this.baja; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        public string Apellido
        {
            get { return this.apellido; }
        }

        public string NomRol
        {
            get { return this.rol.NomRol; }
        }
       
        public string NombreDDL
        {
            get { return this.Nombre + " " + this.apellido; }
        }
        #endregion

        #region Constructor
        public Empleado(int nroEmpleado, string nombre, string apellido, Rol rol)
        {
            this.nroEmpleado = nroEmpleado;
            this.nombre = nombre;
            this.apellido = apellido;
            this.rol = rol;
        }
        #endregion

        #region Metodos
        public double calcularValorHora()
        {
            double valor = 0;

            valor = this.rol.ValorHora;

            return valor;
        }

        public bool bajaEmpleado()
        {
            return this.baja = true;
        }

        public void editarEmpleado (int nuevoNumero, string nombre, string apellido, Rol R)
        {
                this.nroEmpleado = nuevoNumero;
                this.nombre = nombre;
                this.apellido = apellido;
                this.rol = R;
        }
        #endregion

        #region MetodoSerializacion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("nroEmpleado", this.nroEmpleado, typeof(int));
            info.AddValue("nombre", this.nombre, typeof(string));
            info.AddValue("apellido", this.apellido, typeof(string));
            info.AddValue("rol", this.rol, typeof(Rol));
            info.AddValue("baja", this.baja, typeof(bool));

        }
        public Empleado(SerializationInfo info, StreamingContext context)
        {
            this.nroEmpleado = (int)info.GetValue("nroEmpleado", typeof(int));
            this.nombre = (string)info.GetValue("nombre", typeof(string));
            this.apellido = (string)info.GetValue("apellido", typeof(string));
            this.rol = (Rol)info.GetValue("rol", typeof(Rol));
            this.baja = (bool)info.GetValue("baja", typeof(bool));


        }
        #endregion
    }
}
