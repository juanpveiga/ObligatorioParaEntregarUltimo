using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace obligTallerObjWeb
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["perfil"] = null;
            Response.Redirect("CalendarioDeRodajes.aspx");
        }
    }
}