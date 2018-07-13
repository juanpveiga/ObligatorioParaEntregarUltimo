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
    public partial class AltaRodajeEstudio : System.Web.UI.Page
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
                DDLObra.DataSource = f.mostrarObrasActivas();
                DDLObra.DataTextField = "Nombre";
                DDLObra.DataValueField = "Nombre";
                DDLObra.DataBind();

                DDLLugar.DataSource = f.mostrarLugares();
                DDLLugar.DataTextField = "NomLugar";
                DDLLugar.DataValueField = "NomLugar";
                DDLLugar.DataBind();

                plcEstudio.Visible = false;
                plcLocacion.Visible = false;
            }
        }

        protected void btnAltaRodaje_Click(object sender, EventArgs e)
        {
            int nroIden = -1;
            int.TryParse(txtId.Text, out nroIden);

            DateTime fechaInicio = new DateTime();
            DateTime.TryParse(txtFechaCom.Text, out fechaInicio);

            int horaComienzo = -1;
            int.TryParse(txtHoraCom.Text, out horaComienzo);

            int duracion = -1;
            int.TryParse(txtDuracion.Text, out duracion);

            string obra = DDLObra.SelectedValue;

            string lugar = DDLLugar.SelectedValue;

            string usuario = Session["usuario"].ToString();

            if (rbnEstudio.Checked)
            {
                string set = txtSet.Text;
                lblMensaje.Text = f.altaRodajeEstudio(obra, lugar, usuario, duracion, fechaInicio, horaComienzo, nroIden, set);
            }
            else
            {
                string locacion = txtLocacion.Text;
                lblMensaje.Text = f.altaRodajeLocacion(obra, lugar, usuario, duracion, fechaInicio, horaComienzo, nroIden, locacion);
            }
           
        }

        protected void rbtEstudio_CheckedChanged(object sender, EventArgs e)
        {
            plcEstudio.Visible = true;
            plcLocacion.Visible = false;
        }

        protected void rbtLocacion_CheckedChanged(object sender, EventArgs e)
        {
            plcEstudio.Visible = false;
            plcLocacion.Visible = true;
        }
    }
}