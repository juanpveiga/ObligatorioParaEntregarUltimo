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
    public partial class listaRodajesMayorA : System.Web.UI.Page
    {
        private Fachada f = new Fachada();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int monto = -1;
            int.TryParse(TxtMonto.Text, out monto);
            if (monto > 0)
            {
                grillaRodajesMayorA.DataSource = f.rodajesMayorA(monto);
                grillaRodajesMayorA.DataBind();
            }

        }
    }
}