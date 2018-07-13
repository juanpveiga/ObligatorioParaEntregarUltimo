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
    public partial class Login : System.Web.UI.Page
    {
        Fachada f = new Fachada();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void @true(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;
            string perfil = f.buscarPerfilUsuario(username, password);

            if (perfil != "")
            {
                Session["perfil"] = perfil;
                Session["usuario"] = username;
                Response.Redirect("CalendarioDeRodajes.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendarioDeRodajes.aspx");
        }
    }
}