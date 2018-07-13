using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class CRodaje : ISerializable
    {
        #region Atributos
        private static CRodaje instancia;
        private List<Rodaje> rodajes = new List<Rodaje>();
        #endregion

        #region Propiedades
        public static CRodaje Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new CRodaje();
                }
                return instancia;
            }

        }

        public List<Rodaje> Rodajes
        {
            get { return this.rodajes; }
        }
        #endregion

        #region Consturctor Singleton
        private CRodaje()
        {

        }
        #endregion

        #region Metodos

        public bool bajaRodaje(int nroIden)
        {
            bool baja = false;
            Rodaje r = buscarRodaje(nroIden);
            if (r != null && !r.Baja)
            {
                baja = r.bajaRodaje();
            }
            return baja;
        }

        public string finalizarRodaje(int nroIden, Usuario u)
        {
            string mensaje = "No se pudo finalizar el rodaje";
            Rodaje r = buscarRodaje(nroIden);

            if (r != null && r.Baja == false && u != null)
            {
                if (r.EmpleadosRod.Count > 0)
                {
                    mensaje = "Se finalizo el rodaje satisfactoriamente";
                    r.Realizado = true;
                    r.FechaFin = DateTime.Today;
                    r.Usuario = u;
                }
                else
                {
                    mensaje = "El rodaje no cuenta con empleados. No se pudo finalizar";
                }
            }
            
            return mensaje;
        }
        public bool altaRodajeEstudio(Obra o, Lugar l, Usuario u, int duracion, DateTime fechaInicio, int horaComienzo, int nroIden, string set)
        {
            bool alta = false;

            int cantRodajes = rodajes.Count;

            if (buscarRodaje(nroIden) == null && duracion > 0 && horaComienzo >= 0 && set != "" && fechaInicio != new DateTime() &&
                validarFechaLugarRodaje(fechaInicio, l))
            {

                this.rodajes.Add(new Estudio(nroIden, l, fechaInicio, horaComienzo, duracion, o, u, set));

            }
            if (rodajes.Count > cantRodajes)
            {
                alta = true;
            }
            return alta;
        }

        public bool altaRodajeLocacion(Obra o, Lugar l, Usuario u, int duracion, DateTime fechaInicio, int horaComienzo, int nroIden, string locacion)
        {
            bool alta = false;
            int cantRodajes = rodajes.Count;
            if (buscarRodaje(nroIden) == null && duracion > 0 && horaComienzo >= 0 && locacion != "" && fechaInicio != new DateTime() &&
                validarFechaLugarRodaje(fechaInicio, l))
            {
                this.rodajes.Add(new LocacionExt(nroIden, l, fechaInicio, horaComienzo, duracion, o, u, locacion));

            }
            if (rodajes.Count > cantRodajes)
            {
                alta = true;
            }
            return alta;
        }

        public bool validarFechaLugarRodaje(DateTime fechaInicio, Lugar lugar)//valida que en un mismo lugar no se solapen 2 rodajes
        {
            bool valido = true;

            foreach (Rodaje r in this.rodajes)
            {
                if (r.Realizado)
                {
                    if (r.FechaInicio <= fechaInicio && r.FechaFin >= fechaInicio && r.nombreLugar() == lugar.NomLugar)
                    {
                        valido = false;
                    }
                }
                else
                {
                    if (r.FechaInicio <= fechaInicio && r.nombreLugar() == lugar.NomLugar)
                    {
                        valido = false;
                    }
                }
            }
            return valido;
        }

        public bool editarRodaje(Obra o, Lugar l, Usuario u, int duracion, DateTime fechaInicio, int horaComienzo, int nroIden, int nuevoNroIden)
        {
            bool editado = false;

            Rodaje r = buscarRodaje(nroIden);

            if (r != null && r.Baja == false && validarFechaLugarRodaje(fechaInicio, l))
            {

                r.editarRodaje(o, l, u, duracion, fechaInicio, horaComienzo, nroIden, nuevoNroIden);
                editado = true;
            }
            return editado;
        }

        public Rodaje buscarRodaje(int nroIden)
        {
            int i = 0;
            Rodaje r = null;

            while (i < rodajes.Count && r == null)
            {
                if (rodajes[i].NroIden == nroIden)
                {
                    r = rodajes[i];
                }
                i++;
            }
            return r;
        }

        public bool agregarEmpRod(int nroIden, Empleado empleado, int cantHoras, Usuario u)
        {
            bool agregado = false;

            Rodaje r = buscarRodaje(nroIden);

            if (empleado != null && cantHoras > 0 && r != null && r.Baja == false && u != null)
            {
                r.ingresarEmpRod(empleado, cantHoras);
                r.Usuario = u;
                agregado = true;
            }
            return agregado;
        }
        #endregion

        public void asignarFicto(double ficto)
        {
            Estudio.Ficto = ficto;
        }
        public List<Obra> obrasConRodPendiente()
        {
            List<Obra> obrasConRodPendiente = new List<Obra>();

            foreach (Rodaje r in rodajes)
            {
                Obra o = r.buscarObraRodPendiente();

                if (!obrasConRodPendiente.Contains(o))
                {
                    obrasConRodPendiente.Add(o);
                }

            }

            return obrasConRodPendiente;
        }

        public double costoTotalRodNofinalizado()
        {
            double total = 0;

            foreach (Rodaje R in rodajes)
            {
                if (R.penRealizacion())
                {
                    total += R.calcularCosto();
                }
            }

            return total;
        }


        #region mostrarRodaje
        public List<Rodaje> listarRodajeMayorA(double costo)
        {

            List<Rodaje> listaRodajes = new List<Rodaje>();

            if (costo >= 0)
            {
                foreach (Rodaje ro in rodajes)
                {
                    if (ro.calcularCosto() > costo)
                    {
                        listaRodajes.Add(ro);
                    }
                }
                listaRodajes.Sort(new OrdenamientoXcosto());
            }
            return listaRodajes;

        }

        public List<Rodaje> listaRodajeXcosto()
        {
            List<Rodaje> rodajesXcosto = new List<Rodaje>();

            foreach (Rodaje r in rodajes)
            {
                if (r.FechaInicio.Year == DateTime.Today.Year && r.Realizado)
                {
                    rodajesXcosto.Add(r);
                }
            }
            rodajesXcosto.Sort(new OrdenamientoXcosto());

            return rodajesXcosto;
        }


        public bool buscarLugarEnRodaje(Lugar l)
        {
            bool esta = false;
            int i = 0;
            while (i < rodajes.Count && esta == false)
            {
                esta = (rodajes[i].estaLugar(l));


                i++;
            }
            return esta;
        }

        public Lugar buscarLugarEnRodaje2(int nroIden)
        {
            Rodaje r = this.buscarRodaje(nroIden);
            Lugar l = null;

            if (r != null)
            {
                l = r.Lugar;
            }
            return l;
        }

        public Usuario buscarUsuarioEnRodaje(int nroIden)
        {
            Rodaje r = this.buscarRodaje(nroIden);
            Usuario u = null;

            if (r != null)
            {
                u = r.Usuario;
            }
            return u;
        }

        public Obra buscarObraEnRodaje(int nroIden)
        {
            Rodaje r = this.buscarRodaje(nroIden);
            Obra o = null;

            if (r != null)
            {
                o = r.Obra;
            }
            return o;
        }

        public List<EmpEnRod> buscarEmpleadosEnRodaje(int nroIden)
        {
            List<EmpEnRod> empleadosEnRodaje = new List<EmpEnRod>();
            Rodaje r = this.buscarRodaje(nroIden);

            if (r != null)
            {
                empleadosEnRodaje.AddRange(r.EmpleadosRod);
            }
            return empleadosEnRodaje;
        }

        public List<Rodaje> buscarRodajesPendientes()
        {
            List<Rodaje> rodajesPendientes = new List<Rodaje>();

            foreach (Rodaje r in this.rodajes)
            {
                if (!r.Realizado && !r.Baja)
                {
                    rodajesPendientes.Add(r);
                }
            }

            return rodajesPendientes;
        }

        public List<Rodaje> buscarRodajesActivos()
        {
            List<Rodaje> rodajesActivos = new List<Rodaje>();

            foreach (Rodaje r in this.rodajes)
            {
                if (!r.Baja)
                {
                    rodajesActivos.Add(r);
                }
            }
            return rodajesActivos;
        }

        public List<Rodaje> filtrarRodajesPorLugar(List<Rodaje> rodajes, string nomLugar)
        {
            List<Rodaje> rodajesFiltrados = new List<Rodaje>();

            if (nomLugar != "" && rodajes.Count > 0)
            {
                foreach (Rodaje r in rodajes)
                {
                    if (r.traerNomLugar() == nomLugar && r.Baja == false)
                    {
                        rodajesFiltrados.Add(r);
                    }
                }
            }

            return rodajesFiltrados;
        }

        public List<Rodaje> filtrarRodajesPorFechas(List<Rodaje> rodajes, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Rodaje> rodajesFiltrados = new List<Rodaje>();
            DateTime fechaPrueba = new DateTime();

            if (fechaDesde != fechaPrueba && fechaHasta != fechaPrueba && rodajes.Count > 0)
            {
                foreach (Rodaje r in rodajes)
                {
                    if (r.FechaInicio >= fechaDesde && r.FechaInicio <= fechaHasta && r.Baja == false)
                    {
                        rodajesFiltrados.Add(r);
                    }
                }
            }

            return rodajesFiltrados;
        }

        public List<Rodaje> filtrarRodajesPorObra(List<Rodaje> rodajes, string nomObra)
        {
            List<Rodaje> rodajesFiltrados = new List<Rodaje>();

            if (nomObra != "" && rodajes.Count > 0)
            {
                foreach (Rodaje r in rodajes)
                {
                    if (r.traerNomObra() == nomObra && r.Baja == false)
                    {
                        rodajesFiltrados.Add(r);
                    }
                }
            }

            return rodajesFiltrados;
        }

        public List<Rodaje> filtrarRodajesPorTipo(List<Rodaje> rodajes, string tipo)
        {
            List<Rodaje> rodajesFiltrados = new List<Rodaje>();

            if (tipo != "" && rodajes.Count > 0)
            {
                if (tipo == "Estudio")
                {
                    foreach (Rodaje r in rodajes)
                    {
                        if (r is Estudio && r.Baja == false)
                        {
                            rodajesFiltrados.Add(r);
                        }
                    }
                }

                if (tipo == "Locacion")
                {
                    foreach (Rodaje r in rodajes)
                    {
                        if (r is LocacionExt && r.Baja == false)
                        {
                            rodajesFiltrados.Add(r);
                        }
                    }
                }
            }

            return rodajesFiltrados;
        }




        #endregion


        #region metodoSerializacion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("rodajes", this.rodajes, typeof(List<Rodaje>));


        }
        public CRodaje(SerializationInfo info, StreamingContext context)
        {


            this.rodajes = (List<Rodaje>)info.GetValue("rodajes", typeof(List<Rodaje>));
            CRodaje.instancia = this;
        }
        #endregion

    }
}
