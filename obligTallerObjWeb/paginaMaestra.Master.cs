using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace obligTallerObjWeb
{
    public partial class paginaMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["perfil"] != null)
             {
                 if (Session["perfil"].ToString() == "Administrador")
                 {
                     MenuAdmin.Visible = true;
                     MenuAsistente.Visible = false;
                     MenuVisita.Visible = false;
                 }
                 else
                 {
                     MenuAdmin.Visible = false;
                     MenuAsistente.Visible = true;
                     MenuVisita.Visible = false;
                 }
             }
             else
             {

                 MenuAdmin.Visible = false;
                 MenuAsistente.Visible = false;
                 //Response.Redirect("CalendarioDeRodajes.aspx");
             }
        }
    }
}