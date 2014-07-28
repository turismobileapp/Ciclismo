using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NivelDatos;
using Entities;

namespace Presentacion
{    
    public partial class GestionarCiclistas : System.Web.UI.Page
    {
        public CiclistasD ciclistas;//Capa de datos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
                cargarDdl();                
            }
        }

        private void cargarDdl()
        {
            EquipoD equipos = new EquipoD();
            equipos.consultarEquipos();
            ddl_equipo.DataSource = equipos.datatable;
            ddl_equipo.DataValueField = "EquipoID";
            ddl_equipo.DataTextField = "Nombre";
            ddl_equipo.DataBind();
        }
        private void cargarGrid()
        {
            ciclistas = new CiclistasD();
            ciclistas.consultarCiclista();
            gv_ciclistas.DataSource = ciclistas.datatable;
            gv_ciclistas.DataBind();
        }

        protected void gv_ciclistas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "mod":
                        hf_id_ciclista.Value = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                        ddl_equipo.SelectedValue = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        txt_nom.Text = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text;
                        txt_ape.Text = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text;                        
                        txt_edad.Text = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text;
                        ddl_equipo.Enabled = true;
                        txt_nom.ReadOnly = false;
                        txt_ape.ReadOnly = false;
                        txt_edad.ReadOnly = false;
                        P_adi.GroupingText = "Modificar Ciclista";
                        btn_add.Text = "Modificar";
                        P_adi.Visible = true;
                        P_adi.Focus();
                        break;
                    case "eli":
                        hf_id_ciclista.Value = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                        ddl_equipo.SelectedValue = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        txt_nom.Text = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text;
                        txt_ape.Text = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text;                        
                        txt_edad.Text = gv_ciclistas.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text;
                        ddl_equipo.Enabled = false;
                        txt_nom.ReadOnly = true;
                        txt_ape.ReadOnly = true;
                        txt_edad.ReadOnly = true;
                        P_adi.GroupingText = "Eliminar Ciclista";
                        btn_add.Text = "Eliminar";
                        P_adi.Visible = true;
                        P_adi.Focus();
                        break;
                    default: break;
                }
            }
            catch { }
        }

        protected void btn_add_ciclista_Click(object sender, System.EventArgs e)
        {            
            txt_ape.Text = "";
            txt_nom.Text = "";
            txt_edad.Text = "";
            ddl_equipo.Enabled = true;
            txt_nom.ReadOnly = false;
            txt_ape.ReadOnly = false;
            txt_edad.ReadOnly = false;
            P_adi.GroupingText = "Agregar Ciclista";
            btn_add.Text = "Agregar";
            P_adi.Visible = true;
            P_adi.Focus();
        }

        protected void btn_add_Click(object sender, System.EventArgs e)
        {
            if (btn_add.Text.Equals("Agregar"))
            {                
                CiclistasD ciclistas = new CiclistasD();
                CiclistaE c = new CiclistaE();
                c.EquiposID = ddl_equipo.SelectedValue;
                c.Nombres = txt_nom.Text;
                c.Apellidos = txt_ape.Text;
                c.Edad = Convert.ToInt16(txt_edad.Text);
                if (ciclistas.insertarCiclista(c))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Ciclista Agregado');", true);
                    P_adi.Visible = false;
                    cargarGrid();
                }
            }
            else if (btn_add.Text.Equals("Modificar"))//Modificar
            {
                CiclistasD ciclistas = new CiclistasD();
                CiclistaE c = new CiclistaE();
                c.CiclistaID =Convert.ToInt16(hf_id_ciclista.Value);
                c.EquiposID = ddl_equipo.SelectedValue;
                c.Nombres = txt_nom.Text;
                c.Apellidos = txt_ape.Text;
                c.Edad = Convert.ToInt16(txt_edad.Text);
                if (ciclistas.actualizarCiclista(c))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Ciclista Actualizado');", true);
                    P_adi.Visible = false;
                    cargarGrid();
                }
            }
            else//Eliminar
            {
                CiclistasD ciclistas = new CiclistasD();                
                if (ciclistas.eliminarCiclista(Convert.ToInt16(hf_id_ciclista.Value)))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Ciclista Eliminado');", true);
                    P_adi.Visible = false;
                    cargarGrid();
                }
            }
        }

        protected void btn_can_Click(object sender, System.EventArgs e)
        {
            txt_ape.Text = "";
            txt_nom.Text = "";
            txt_edad.Text = "";
            P_adi.Visible = false;
        }
    }
}