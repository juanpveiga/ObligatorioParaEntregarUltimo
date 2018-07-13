using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using obligTallerObjDominio;
using System.IO;

namespace FachadaRepositorio
{
    public class Fachada
    {
        #region Obra
        public string altaObra(string nombre, DateTime fechaIni, DateTime fechaPromFin, double costoBase)
        {
            string mensaje = "No se pudo dar de alta la obra.";

            if (CObra.Instancia.altaObra(nombre, fechaIni, fechaPromFin, costoBase))
            {
                mensaje = "Se dio de alta la obra correctamente.";
            }
            return mensaje;
        }

        public bool bajaObra(string nombreObra)
        {
            return CObra.Instancia.bajaObra(nombreObra);

        }

        public bool editarObra(string nombre, string nuevoNombre, DateTime fechaIni, DateTime fechaPromFin, double costoBase)
        {
            return CObra.Instancia.editarObra(nombre, nuevoNombre, fechaIni, fechaPromFin, costoBase);
        }

        public List<Obra> obraConRodPendiente()
        {
            return CRodaje.Instancia.obrasConRodPendiente();
        }

        public List<Obra> obrasAtrasadas()
        {
            return CObra.Instancia.obrasAtrasadas();
        }

        public List<Obra> mostrarObrasActivas()
        {
            return CObra.Instancia.buscarObrasActivas();
        }
        #endregion

        #region Rodaje

        public string altaRodajeEstudio(string nomObra, string nomLugar, string cedulaUsuario, int duracion, DateTime fechaInicio, int horaComienzo, int nroIden, string set)

        {
            string mensaje = "No se pudo dar de alta el rodaje.";
            Obra o = CObra.Instancia.buscarObra(nomObra);
            if (o != null && o.Baja == false)
            {
                Lugar l = CLugar.Instancia.buscarLugar(nomLugar);
                if (l != null && l.Baja == false)
                {
                    Usuario u = CUsuario.Instancia.buscarUsuario(cedulaUsuario);
                    if (u != null)
                    {

                        if (CRodaje.Instancia.altaRodajeEstudio(o, l, u, duracion, fechaInicio, horaComienzo, nroIden, set))
                        {
                            mensaje = "Se dio correctamente de alta el rodaje.";
                        }

                    }
                }
            }
            return mensaje;
        }

        public string altaRodajeLocacion(string nomObra, string nomLugar, string cedulaUsuario, int duracion, DateTime fechaInicio, int horaComienzo, int nroIden, string locacion)
        {
            string mensaje = "No se pudo de dar de alta el rodaje.";
            Obra o = CObra.Instancia.buscarObra(nomObra);
            if (o != null && o.Baja == false)
            {
                Lugar l = CLugar.Instancia.buscarLugar(nomLugar);
                if (l != null && l.Baja == false)
                {
                    Usuario u = CUsuario.Instancia.buscarUsuario(cedulaUsuario);
                    if (u != null)
                    {

                        if (CRodaje.Instancia.altaRodajeLocacion(o, l, u, duracion, fechaInicio, horaComienzo, nroIden, locacion))
                        {
                            mensaje = "Se dio correctamente de alta el rodaje.";
                        }

                    }
                }
            }
            return mensaje;
        }

        public string agregarEmpleado(int idRodaje, int nroEmpleado, int cantHoras, string usuario)
        {
            string mensaje = "No se pudo agregar el empleado.";

            Empleado e = CEmpleado.Instancia.buscarEmpleado(nroEmpleado);
            Usuario u = CUsuario.Instancia.buscarUsuario(usuario);

            if (e != null && e.Baja == false && u != null)
            {
                if (CRodaje.Instancia.agregarEmpRod(idRodaje, e, cantHoras, u))
                {
                    mensaje = "Se agrego el empleado correctamente.";
                }
            }

            return mensaje;
        }

        public bool bajaRodaje(int nroIden)
        {
            return CRodaje.Instancia.bajaRodaje(nroIden);
        }

        public string finalizarRodaje(int nroIden, string CIUsuario)
        {
            string mensaje = "No se pudo finalizar el rodaje";
            Usuario u = CUsuario.Instancia.buscarUsuario(CIUsuario);

            if(u != null)
            {
                    mensaje = CRodaje.Instancia.finalizarRodaje(nroIden, u);
            }
            
            return mensaje;
        }

        public bool editarRodaje(string nomObra, string nomLugar, string cedulaUsuario, int duracion, DateTime fechaInicio, int horaComienzo, int nroIden, int nuevoNumero)
        {
            bool editado = false;
            Obra o = CObra.Instancia.buscarObra(nomObra);
            if (o != null && o.Baja == false)
            {
                Lugar l = CLugar.Instancia.buscarLugar(nomLugar);
                if (l != null && l.Baja == false)
                {
                    Usuario u = CUsuario.Instancia.buscarUsuario(cedulaUsuario);
                    if (u != null)
                    {

                        CRodaje.Instancia.editarRodaje(o, l, u, duracion, fechaInicio, horaComienzo, nroIden, nuevoNumero);
                        editado = true;
                    }
                }
            }
            return editado;
        }

        public List<Rodaje> rodajesMayorA(double costo)
        {
            return CRodaje.Instancia.listarRodajeMayorA(costo);
        }

        public List<Rodaje> rodajesOrdenPorcosto()
        {
            return CRodaje.Instancia.listaRodajeXcosto();
        }

        public double costoTotalRodNofinalizado()
        {
            return CRodaje.Instancia.costoTotalRodNofinalizado();
        }


        public List<Rodaje> mostrarRodajesPendientes()// muestra los rodajes que estan sin finalizar
        {
            return CRodaje.Instancia.buscarRodajesPendientes();
        }

        public List<Rodaje> mostrarRodajesActivos()// muestra los rodajes que no han sido dados de baja logica
        {
            return CRodaje.Instancia.buscarRodajesActivos();
        }

        public List<Rodaje> filtrarRodajes(string tipo, string nomObra, DateTime fechaDesde, DateTime fechaHasta, string nomLugar)
        {
            DateTime fechaPrueba = new DateTime();
            List<Rodaje> rodajesFiltrados = new List<Rodaje>();
            List<Rodaje> listaAuxiliar = new List<Rodaje>();

            rodajesFiltrados.AddRange(this.mostrarRodajesActivos());

            if (tipo != "")
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorTipo(rodajesFiltrados, tipo));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);

            }

            if (nomObra != "")
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorObra(rodajesFiltrados, nomObra));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);
            }

            if (fechaDesde != fechaPrueba && fechaHasta != fechaPrueba)
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorFechas(rodajesFiltrados, fechaDesde, fechaHasta));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);
            }

            if (nomLugar != "")
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorLugar(rodajesFiltrados, nomLugar));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);
            }

            return rodajesFiltrados;
        }

        public List<Rodaje> filtrarRodajesFinalizar(string tipo, string nomObra, DateTime fechaDesde, DateTime fechaHasta, string nomLugar)
        {
            DateTime fechaPrueba = new DateTime();
            List<Rodaje> rodajesFiltrados = new List<Rodaje>();
            List<Rodaje> listaAuxiliar = new List<Rodaje>();

            rodajesFiltrados.AddRange(this.mostrarRodajesPendientes());

            if (tipo != "")
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorTipo(rodajesFiltrados, tipo));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);

            }

            if (nomObra != "")
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorObra(rodajesFiltrados, nomObra));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);
            }

            if (fechaDesde != fechaPrueba && fechaHasta != fechaPrueba)
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorFechas(rodajesFiltrados, fechaDesde, fechaHasta));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);
            }

            if (nomLugar != "")
            {
                listaAuxiliar.Clear();
                listaAuxiliar.AddRange(CRodaje.Instancia.filtrarRodajesPorLugar(rodajesFiltrados, nomLugar));
                rodajesFiltrados.Clear();
                rodajesFiltrados.AddRange(listaAuxiliar);
            }

            return rodajesFiltrados;
        }

        public List<Obra> mostrarObraEnRodaje(int nroIden)
        {
            List<Obra> obraEnRodaje = new List<Obra>();
            Obra o = CRodaje.Instancia.buscarObraEnRodaje(nroIden);
            if (o != null)
            {
                obraEnRodaje.Add(o);
            }
            return obraEnRodaje;
        }

        public List<Lugar> mostrarLugarEnRodaje(int nroIden)
        {
            List<Lugar> lugarEnRodaje = new List<Lugar>();
            Lugar l = CRodaje.Instancia.buscarLugarEnRodaje2(nroIden);
            if (l != null)
            {
                lugarEnRodaje.Add(l);
            }
            return lugarEnRodaje;
        }

        public List<Usuario> mostrarUsuarioEnRodaje(int nroIden)
        {
            List<Usuario> usuarioEnRodaje = new List<Usuario>();
            Usuario u = CRodaje.Instancia.buscarUsuarioEnRodaje(nroIden);
            if(u != null)
            {
                usuarioEnRodaje.Add(u);
            }
            return usuarioEnRodaje;
        }

        public List<EmpEnRod> mostrarEmpleadosEnRodaje(int nroIden)
        {
            return CRodaje.Instancia.buscarEmpleadosEnRodaje(nroIden);
        }
        #endregion

        public void obtenerFictoRodaje(string rutaArchivo)
        {
            FileStream miArchivo = new FileStream(rutaArchivo, FileMode.Open);
            StreamReader sr = new StreamReader(miArchivo);

            string linea = sr.ReadLine();

            if (linea != null)
            {
                String[] datos = linea.Split(':');
                double ficto = 0;
                double.TryParse(datos[1], out ficto);
                CRodaje.Instancia.asignarFicto(ficto);
            }
            sr.Close();
        }

        #region Lugares
        public string altaLugar(string nombre, string direccion)
        {
            string mensaje = "Ingrese datos validos.";
            if (nombre != "" && direccion != "")
            {
                if (CLugar.Instancia.altaLugar(nombre, direccion))
                {
                    mensaje = "Se realizo el alta satisfactoriamente.";
                }
            }
            return mensaje;
        }

        public string bajaLugar(string nombre)
        {
            string mensaje = "No se pudo dar de baja el lugar.";

            if (CLugar.Instancia.bajaLugar(nombre))
            {
                mensaje = "Se dio de baja correctamente el lugar;";
            }
            return mensaje;
        }

        public string editarLugar(string nombre, string nombreNuevo, string direccion)
        {
            string mensaje = "No se pudo editar el lugar.";

            if (CLugar.Instancia.editarLugar(nombre, nombreNuevo, direccion))
            {
                mensaje = "Se edito el lugar satisfactoriamente.";
            }
            return mensaje;
        }

        public List<Lugar> mostrarLugares()
        {
            return CLugar.Instancia.Lugares;
        }
        #endregion

        #region Empleados

        public string altaEmpleado(int nroEmpleado, string nombre, string apellido, string nomRol)
        {
            string mensaje = "Ingrese datos validos.";
            Rol r = CRol.Instancia.buscarRol(nomRol);
            if (r != null && nombre != "" && apellido != "")
            {
                if (CEmpleado.Instancia.altaEmpleado(nroEmpleado, nombre, apellido, r))
                {
                    mensaje = "Se realizao el alta satisfactoriamente.";
                }
            }
            return mensaje;
        }

        public bool bajaEmpleado(int nroEmpleado)
        {
            return CEmpleado.Instancia.bajaEmpleado(nroEmpleado);

        }

        public bool editarEmpleado(int nroEmpleado, int nuevoNumero, string nombre, string apellido, string nomRol)
        {
            bool editado = false;
            Rol R = CRol.Instancia.buscarRol(nomRol);
            if (R != null)
            {
                editado = CEmpleado.Instancia.editarEmpleado(nroEmpleado, nuevoNumero, nombre, apellido, R);
            }
            return editado;
        }

        public List<Empleado> mostrarEmpleados()
        {
            return CEmpleado.Instancia.Empleados;
        }
        #endregion

        #region Usuarios
        public string altaUsuario(string cedula, string contraseña, string primerNom, string segundoNom,
            string primerAp, string segundoAp, string email, string direccion, string telefono, string perfil)
        {
            string mensaje = "No se pudo dar de alta el usuario.";
            if (CUsuario.Instancia.altaUsuario(cedula, contraseña, primerNom, segundoNom, primerAp,
                segundoAp, email, direccion, telefono, perfil))
            {
                mensaje = "Se dio de alta el usuario correctamente.";
            }
            return mensaje;
        }

        public string buscarPerfilUsuario(string nombre, string password)
        {

            return CUsuario.Instancia.buscarPerfilUsuario(nombre, password);
        }
        #endregion

        #region Rol

        public string altaRol(string nomRol, double valorHora)
        {
            string mensaje = "No se pudo dar de alta el rol.";

            if(nomRol != "" && valorHora >= 0)
            {
                if(CRol.Instancia.altaRol(nomRol, valorHora))
                {
                    mensaje = "Se dio de alta el rol correctamente.";
                }
            }
            return mensaje;
        }

        #endregion

        #region Datos de Prueba

        public void precargaDatos()
        {

            altaLugar("Estudio A ", "Calle A Nro 345");
            altaLugar("Estudio B ", "Calle B Nro 350");
            altaLugar("Estudio C ", "Calle B Nro 370");
            altaLugar("Estudio D ", "Calle C Nro 111");
            altaLugar("Estudio E ", "Calle T Nro 290");
            altaLugar("Estudio F ", "Calle H Nro 457");
            altaLugar("Estudio G ", "Calle T Nro 150");

            altaObra("El Gato con Botas", new DateTime(2017, 01, 03), DateTime.Today.AddDays(10), 50000);
            altaObra("La Estafa", new DateTime(2017, 01, 05), DateTime.Today.AddDays(10), 150000);
            altaObra("La Cena",new DateTime(2017, 01, 10), DateTime.Today.AddDays(10), 80000);
            altaObra("Juegos Peligrosos",new DateTime(2017, 01, 18), DateTime.Today.AddDays(10), 120000);
            altaObra("El Silencio", new DateTime(2017, 01, 22), DateTime.Today.AddDays(10), 120000);
            altaObra("Zanahoria", new DateTime(2017, 01, 25), DateTime.Today.AddDays(10), 120000);

            altaUsuario("12345678", "nosoyelprocer", "Jose", "Gervacio", "Gonazalez", "", "Gervacio@gmail.com", "Plaza Independencia 001", "29004554", "Administrador");
            altaUsuario("43525678", "soyjuan1", "Juan", "Pedro", "Veiga", "", "juanpveiga@gmail.com", "Rodo 4351", "29004554", "Asistente");
            altaUsuario("12354321", "soymarcelo", "Marcelo", "Agustin", "Sanchez", "", "marcelo@gmail.com", "Guana 8907", "29004554", "Administrador");
            altaUsuario("11223344", "prog1234", "Lucas", "Ivan", "Lorenzo", "", "lucas2211@gmail.com", "Colonia 1243", "29008125", "Asistente");

            altaRol("Direccion", 250);
            altaRol("Camara", 150);
            altaRol("Sonido", 150);
            altaRol("Escenografia", 200);
            altaRol("Vestuario", 125);
            altaRol("Maquillaje", 100);

            altaEmpleado(1150, "Mathias", "Gonzalez", "Direccion");
            altaEmpleado(2235, "Matilda", "Martinez", "Direccion");
            altaEmpleado(1140, "Agustin", "Fernandez", "Camara");
            altaEmpleado(2230, "Lucas", "Pereira", "Camara");
            altaEmpleado(1452, "Agustin", "Cabrera", "Sonido");
            altaEmpleado(4756, "Micaela", "Rodriguez", "Camara");
            altaEmpleado(7586, "Alberto", "Dominguez", "Escenografia");
            altaEmpleado(6384, "Florencia", "Machado", "Vestuario");
            altaEmpleado(3324, "Valeria", "Delgado", "Maquillaje");
            altaEmpleado(4568, "Federico", "Pombo", "Maquillaje");

            altaRodajeEstudio("El Gato con Botas", "Estudio A ", "12345678", 20, new DateTime(2017, 02, 03), 2230, 11123, "Set A");
            altaRodajeEstudio("La Estafa", "Estudio B ", "12345678", 20, new DateTime(2017, 02, 14), 2230, 11122, "Set B");
            altaRodajeEstudio("La Cena", "Estudio C ", "12345678", 20, new DateTime(2017, 02, 15), 2230, 33213, "Set C");
            altaRodajeEstudio("El Gato con Botas", "Estudio D ", "12345678", 20, new DateTime(2017, 02, 20), 2230, 22434, "Set D");
            altaRodajeEstudio("Juegos Peligrosos", "Estudio E ", "12345678", 20, new DateTime(2017, 01, 30), 2230, 44735, "Set E");
            altaRodajeLocacion("El Silencio", "Estudio F ", "12345678", 20, new DateTime(2017, 02, 23), 2230, 55786, "Interna");
            altaRodajeLocacion("Zanahoria", "Estudio G ", "12345678", 20, new DateTime(2017, 03, 02), 2230, 99787, "Exterior");

            agregarEmpleado(11123, 1150, 25, "12345678");
            agregarEmpleado(11123, 1140, 16, "12345678");
            agregarEmpleado(11123, 4568, 12, "12345678");
            agregarEmpleado(11122, 2235, 40, "12345678");
            agregarEmpleado(11122, 1452, 28, "12354321");
            agregarEmpleado(11122, 6384, 15, "12354321");
            agregarEmpleado(55786, 2230, 36, "12354321");
            agregarEmpleado(55786, 3324, 20, "12354321");

            finalizarRodaje(11122, "12345678");
            finalizarRodaje(55786, "12354321");
        }

        #endregion

        

    }
}
