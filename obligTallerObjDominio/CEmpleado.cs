using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class CEmpleado : ISerializable
    {
        #region Atributos
        private List<Empleado> empleados = new List<Empleado>();
        private static CEmpleado instancia;
        #endregion

        #region Propiedades
        public static CEmpleado Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new CEmpleado();
                }
                return instancia;
            }
            

            
        }

        public List<Empleado> Empleados
        {
            get { return this.empleados; }
        }
        #endregion

        #region Constructor singleton
        private CEmpleado()
        {

        }
        #endregion

        #region Metodos
        public bool altaEmpleado(int nroEmpleado, string nombre, string apellido, Rol rol)
        {
            bool agregado = false;
            int cantEmp = empleados.Count;
            
            if (buscarEmpleado(nroEmpleado) == null && nombre != "" && apellido != "")
            {
                this.empleados.Add(new Empleado(nroEmpleado, nombre, apellido, rol));
            }

            if(cantEmp < empleados.Count)
            {
                agregado = true;
            }

            return agregado;
        }

        public bool bajaEmpleado(int nroEmpleado)
        {
            bool baja = false;

            Empleado e = buscarEmpleado(nroEmpleado);
            if(e != null)
            {
               baja = e.bajaEmpleado();
                
            }

            return baja;
        }

        public Empleado buscarEmpleado(int nroEmpleado)
        {
            Empleado e = null;
            int i = 0;

            while(i < empleados.Count && e == null)
            {
                if(empleados[i].NroEmpleado == nroEmpleado)
                {
                    e = empleados[i];
                }
                i++;
            }
            return e;
        }

        public bool editarEmpleado(int nroEmpleado,int nuevoNumero,string nombre,string apellido,Rol r)
        {
            bool editado = false;

            Empleado e = buscarEmpleado(nroEmpleado);
            if ( e != null && !e.Baja)
            {
                e.editarEmpleado(nuevoNumero, nombre, apellido, r);
                editado = true;
            }
            return editado;
        }
        #endregion

        #region MetodosSerializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("empleados", this.empleados, typeof(List<Empleado>));


        }
        public CEmpleado(SerializationInfo info, StreamingContext context)
        {


            this.empleados = (List<Empleado>)info.GetValue("empleados", typeof(List<Empleado>));
            CEmpleado.instancia = this;
        }
        #endregion
    }
}
