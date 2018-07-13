using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FachadaRepositorio;
using obligTallerObjDominio;

namespace obligTallerObjWeb
{
    public partial class CalendarioDeRodajes : System.Web.UI.Page
    {
        Fachada f = new Fachada();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                plcTipo.Visible = false;
                plcObra.Visible = false;
                plcFecha.Visible = false;
                plcLugar.Visible = false;
                grillaRodajes.Visible = false;
                plcObraRodaje.Visible = false;
                plcLugarRodaje.Visible = false;
                plcEmpleadoRodaje.Visible = false;
                plcUsuarioRodaje.Visible = false;

                DDLObra.DataSource = f.mostrarObrasActivas();
                DDLObra.DataTextField = "Nombre";
                DDLObra.DataValueField = "Nombre";
                DDLObra.DataBind();

                DDLLugar.DataSource = f.mostrarLugares();
                DDLLugar.DataTextField = "NomLugar";
                DDLLugar.DataValueField = "NomLugar";
                DDLLugar.DataBind();
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListItem li in chkFiltros.Items)
            {
                if (li.Selected)
                {
                    if(li.Value == "Tipo")
                    {
                        plcTipo.Visible = true;
                    }
                    if(li.Value == "Obra")
                    {
                        plcObra.Visible = true;
                    }
                    if(li.Value == "Fechas")
                    {
                        plcFecha.Visible = true;
                    }
                    if(li.Value == "Lugar")
                    {
                        plcLugar.Visible = true;
                    }
                    
                }
                else
                {
                    if (li.Value == "Tipo")
                    {
                        plcTipo.Visible = false;
                    }
                    if (li.Value == "Obra")
                    {
                        plcObra.Visible = false;
                    }
                    if (li.Value == "Fechas")
                    {
                        plcFecha.Visible = false;
                    }
                    if (li.Value == "Lugar")
                    {
                        plcLugar.Visible = false;
                    }
                }
            }

        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            plcObraRodaje.Visible = false;
            plcLugarRodaje.Visible = false;
            plcUsuarioRodaje.Visible = false;
            plcEmpleadoRodaje.Visible = false;
            lblMensajeEmp.Text = "";

            string tipo = "";
            string nomObra = "";
            DateTime fechaDesde = new DateTime();
            DateTime fechaHasta = new DateTime();
            string nomLugar = "";
            List<Rodaje> rodajesGrilla = new List<Rodaje>();

            foreach (ListItem li in chkFiltros.Items)
            {
                if (li.Selected)
                {
                    if (li.Value == "Tipo")
                    {
                        tipo = DDLTipo.SelectedValue;
                    }
                    if (li.Value == "Obra")
                    {
                        nomObra = DDLObra.SelectedValue;
                    }
                    if (li.Value == "Fechas")
                    {
                        DateTime.TryParse(txtFechaDesde.Text, out fechaDesde);
                        DateTime.TryParse(txtFechaHasta.Text, out fechaHasta);
                    }
                    if (li.Value == "Lugar")
                    {
                        nomLugar = DDLLugar.SelectedValue;
                    }
                }
            }

            rodajesGrilla = f.filtrarRodajes(tipo, nomObra, fechaDesde, fechaHasta, nomLugar);
            if (rodajesGrilla.Count > 0)
            {
                lblMensaje.Text = "";
                grillaRodajes.DataSource = rodajesGrilla;
                grillaRodajes.DataBind();
                grillaRodajes.Visible = true;
            }
            else
            {
                lblMensaje.Text = "No se encontro ningun rodaje con esos filtros.";
                grillaRodajes.DataBind();
            }
        }

        protected void grillaRodajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EmpEnRod> empleadosRodaje = new List<EmpEnRod>();
            int nroIden = -1;
            int.TryParse(grillaRodajes.SelectedDataKey.Value.ToString(), out nroIden);
            string perfilUsuario = "";
            if(Session["perfil"] != null)
            {
                perfilUsuario = Session["perfil"].ToString();
            }

            grillaObra.DataSource = f.mostrarObraEnRodaje(nroIden);
            grillaObra.DataBind();
            plcObraRodaje.Visible = true;

            grillaLugar.DataSource = f.mostrarLugarEnRodaje(nroIden);
            grillaLugar.DataBind();
            plcLugarRodaje.Visible = true;


            if (perfilUsuario == "Administrador")
            {
                grillaUsuario.DataSource = f.mostrarUsuarioEnRodaje(nroIden);
                grillaUsuario.DataBind();
                plcUsuarioRodaje.Visible = true;
            }

            empleadosRodaje = f.mostrarEmpleadosEnRodaje(nroIden);

            if(empleadosRodaje.Count > 0)
            {
                lblMensajeEmp.Text = "";
                grillaEmpleados.DataSource = empleadosRodaje;
                grillaEmpleados.DataBind();
                plcEmpleadoRodaje.Visible = true;
            }
            else
            {
                lblMensajeEmp.Text = "Aun no hay empleados en el rodaje";
                plcEmpleadoRodaje.Visible = false;
            }
        }
    }
}