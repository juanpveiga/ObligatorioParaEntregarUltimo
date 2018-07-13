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
    public partial class ListadoRodajesPorCosto : System.Web.UI.Page
    {
        Fachada f = new Fachada();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
            {
                if (Session["perfil"].ToString() == "Administrador" || Session["perfil"].ToString() == "Asistente")
                {

                }
                else
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
                grillaCostoRodajes.DataSource = f.rodajesOrdenPorcosto();
                grillaCostoRodajes.DataBind();
            }
        }
    }
}