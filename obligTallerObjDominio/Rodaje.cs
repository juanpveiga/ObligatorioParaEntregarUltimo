using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public abstract class Rodaje : ISerializable
    {
        #region Atributos
        private int nroIden;
        private Lugar lugar;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int hora;
        private int duracion;
        private List<EmpEnRod> empleadosRod = new List<EmpEnRod>();
        private bool realizado;
        private Obra obra;
        private Usuario usuario;
        private bool baja;
        #endregion

        #region Propiedades

       
        public int NroIden
        {
            get { return nroIden; }
            set { this.nroIden = value; }
        }

        public string DDLNombre
        {
            get
            {
                return "NroIdenRod: " + this.NroIden.ToString() + " - NomObra: " + this.obra.Nombre;
            }
        }

        public bool Realizado
        {
            get
            {
                return this.realizado;
            }
            set
            {
                this.realizado = value;
            }
        }

        public string RealizadoGrilla
        {
            get
            {
                string confirmar = "";
                if (this.realizado)
                {
                    confirmar = "Si";
                }
                else
                {
                    confirmar = "No";
                }

                return confirmar;
            }
        }

        public DateTime FechaInicio
        {
            get {return this.fechaInicio; }
            set { this.fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return this.fechaFin; }
            set { this.fechaFin = value; }
        }

        public string FechaInicioGrilla
        {
            get { return this.fechaInicio.ToShortDateString(); }
        }

        public string FechaFinGrilla
        {
            get
            {
                string fechaFinGrilla = "";

                if (this.realizado)
                {
                    fechaFinGrilla = this.fechaFin.ToShortDateString();
                }
                else
                {
                    fechaFinGrilla = "Pendiente";
                }
                return fechaFinGrilla;
            }
        }
       public Obra Obra
        {
            get { return this.obra; }
            set { this.obra = value; }
        }
        public string NombreLugar
        {
            get
            {
                return this.lugar.NomLugar;
            }
        }
        public string NombreObra
        {
            get
            {
                return this.obra.Nombre;
            }
        }

        public Lugar Lugar
        {
            get { return this.lugar; }
            set { this.lugar = value; }
        }

        public int Hora
        {
            get { return this.hora; }
            set { this.hora = value; }
        }

        public int Duracion
        {
            get { return this.duracion; }
            set { this.duracion = value; }
        }

        public double Costo
        {
            get
            {
               return this.calcularCosto();
            }
        }

        public string NomObra
        {
            get { return this.obra.Nombre; }
        }

        public string NomLugar
        {
            get { return this.lugar.NomLugar; }
        }

        public List<EmpEnRod> EmpleadosRod
        {
            get { return this.empleadosRod; }
            set { this.empleadosRod = value; }
        }

        public string Tipo
        {
            get
            {
                string tipo = "";
                if(this is Estudio)
                {
                    tipo = "Estudio";
                }
                if(this is LocacionExt)
                {
                    tipo = "Locacion";
                }

                return tipo;
                
            }
        }

        public bool Baja
        {
            get
            {
                return this.baja;
            }
            set
            {

                this.baja = value;

            }
        }

        public Usuario Usuario
        {
            get
            {
                return this.usuario;
            }

            set
            {
                this.usuario = value;
            }
        }

        #endregion

        
        #region Constructor
        public Rodaje(int nroIden, Lugar lugar, DateTime fechaInicio, int hora, int duracion, Obra obra, Usuario usuario)
        {
            this.nroIden = nroIden;
            this.lugar = lugar;
            this.fechaInicio = fechaInicio;
            this.fechaFin = new DateTime();
            this.hora = hora;
            this.duracion = duracion;
            this.realizado = false;
            this.obra = obra;
            this.usuario = usuario;
            this.baja = false;
        }
        #endregion

        #region Metodos
        public bool ingresarEmpRod(Empleado empleado, int cantHoras)
        {
            bool agregado = false;
            int cantEmpRod = empleadosRod.Count;

            if(empleado != null)
            {
                this.empleadosRod.Add(new EmpEnRod(empleado, cantHoras));
            }

            if(cantEmpRod < empleadosRod.Count)
            {
                agregado = true;
            }

            return agregado;
        }

        public bool bajaRodaje () // Baja logica cambia de estado.
        {
            return this.baja = true;
        }

        public string nombreLugar()
        {
            return this.lugar.NomLugar;
        }
        
        public void editarRodaje(Obra o,Lugar  l,Usuario u,int duracion,DateTime fechaInicio,int horaComienzo, int nroIden, int nuevoNroIden)
        {
           
                this.obra = o;
                this.lugar = l;
                this.usuario = u;
                this.duracion = duracion;
                this.fechaInicio = fechaInicio;
                this.hora = horaComienzo;
                this.nroIden = nuevoNroIden;


        }

        public abstract double calcularCosto();

        public double calcularCostoParcial()
        {
            return this.obra.CostoBase + calculoCostoPersonal();
        }
        
          
        

        public double calculoCostoPersonal()
        {
            double costoEmpleados = 0;

            foreach( EmpEnRod emp in empleadosRod)
            {
                costoEmpleados += emp.calcularSalario();
            }
            return costoEmpleados;
        }


        public bool estaLugar (Lugar l) //con esta funcion confirma la existencia de un Lugar en el rodaje. Para poder la baja del lugar posteriormente.
        {
            bool esta = false;
            if(this.lugar == l)
            {
                esta = true;
            }
            return esta;
        }


        public Obra buscarObraRodPendiente()
        {
            Obra o = null;
            if (!this.realizado)
            {
                o = this.obra;
            }
            return o;
        }// esta funcion devuelve la Obra del rodaje pendiente.

        public bool penRealizacion()
        {
            bool finalizado = false;
            if (!this.realizado)
            {
                finalizado = true;
            }

            return finalizado;
        }

        public string traerNomObra()
        {
            return this.obra.Nombre;
        }

        public string traerNomLugar()
        {
            return this.lugar.NomLugar;
        }
        #endregion

        #region MetodosSerializacion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
        public Rodaje(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion
    }
}
