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
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        private Fachada f = new Fachada();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
            {
                if (Session["perfil"].ToString() != "Administrador")
                {
                    Response.Redirect("CalendarioDeRodajes.aspx");
                }
            }
            else
            {
                
                Response.Redirect("CalendarioDeRodajes.aspx");
            }

            if (!IsPostBack)
            {
                DDLRodaje.DataSource = f.mostrarRodajesPendientes();
                DDLRodaje.DataTextField = "DDLNombre";
                DDLRodaje.DataValueField = "NroIden";
                DDLRodaje.DataBind();

                DDLEmpleado.DataSource = f.mostrarEmpleados();
                DDLEmpleado.DataTextField = "NombreDDL";
                DDLEmpleado.DataValueField = "NroEmpleado";
                DDLEmpleado.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int nroIdenRodaje = -1;
            int.TryParse(DDLRodaje.SelectedValue, out nroIdenRodaje);

            int nroEmpleado = -1;
            int.TryParse(DDLEmpleado.SelectedValue, out nroEmpleado);

            int cantHoras = -1;
            int.TryParse(txtCantHoras.Text, out cantHoras);

            string usuario = Session["usuario"].ToString();

            lblMensaje.Text = f.agregarEmpleado(nroIdenRodaje, nroEmpleado, cantHoras, usuario);
        }
    }
}