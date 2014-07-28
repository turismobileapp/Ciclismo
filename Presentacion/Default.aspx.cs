using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NivelDatos;
using Entities;

namespace Presentacion
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            CiclistasD ciclistas = new CiclistasD();
            ciclistas.consultarCiclistaMasJovenPorEquipo();
            gv_ciclistas.DataSource = ciclistas.datatable;
            gv_ciclistas.DataBind();
        }
    }
}
