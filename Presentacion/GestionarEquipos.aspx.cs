using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NivelDatos;
using Entities;

namespace Presentacion
{
    public partial class GestionarEquipos : System.Web.UI.Page
    {
        public EquipoD ciclistas;//Capa de datos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            ciclistas = new EquipoD();
            ciclistas.consultarEquipos();
            gv_equipos.DataSource = ciclistas.datatable;
            gv_equipos.DataBind();
        }

        protected void gv_equipos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "mod":
                        hf_id_equipo.Value = gv_equipos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;                        
                        txt_nom.Text = gv_equipos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        txt_des.Text = gv_equipos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text;                        
                        txt_nom.ReadOnly = false;
                        txt_des.ReadOnly = false;
                        P_adi.GroupingText = "Modificar Equipo";
                        btn_add.Text = "Modificar";
                        P_adi.Visible = true;
                        P_adi.Focus();
                        break;
                    case "eli":
                        hf_id_equipo.Value = gv_equipos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;                        
                        txt_nom.Text = gv_equipos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                        txt_des.Text = gv_equipos.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text;                        
                        txt_nom.ReadOnly = true;
                        P_adi.GroupingText = "Eliminar Equipo";
                        btn_add.Text = "Eliminar";
                        P_adi.Visible = true;
                        P_adi.Focus();
                        break;
                    default: break;
                }
            }
            catch { }
        }

        protected void btn_add_equipo_Click(object sender, System.EventArgs e)
        {
            txt_des.Text = "";
            txt_nom.Text = "";            
            txt_nom.ReadOnly = false;
            txt_des.ReadOnly = false;
            P_adi.GroupingText = "Agregar Equipo";
            btn_add.Text = "Agregar";
            P_adi.Visible = true;
            P_adi.Focus();
        }

        protected void btn_add_Click(object sender, System.EventArgs e)
        {
            if (btn_add.Text.Equals("Agregar"))
            {
                EquipoD ciclistas = new EquipoD();
                EquipoE c = new EquipoE();                
                c.Nombre = txt_nom.Text;
                c.Descripcion = txt_des.Text;                
                if (ciclistas.insertarEquipo(c))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Equipo Agregado');", true);
                    P_adi.Visible = false;
                    cargarGrid();
                }
            }
            else if (btn_add.Text.Equals("Modificar"))//Modificar
            {
                EquipoD ciclistas = new EquipoD();
                EquipoE c = new EquipoE();
                c.EquipoID = Convert.ToInt16(hf_id_equipo.Value);                
                c.Nombre = txt_nom.Text;
                c.Descripcion = txt_des.Text;                
                if (ciclistas.actualizarEquipo(c))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Equipo Actualizado');", true);
                    P_adi.Visible = false;
                    cargarGrid();
                }
            }
            else//Eliminar
            {
                CiclistasD ciclistas = new CiclistasD();
                //ciclistas.CiclistaID = hf_id_equipo.Value;
                if (ciclistas.eliminarCiclista(Convert.ToInt16(hf_id_equipo.Value)))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Equipo Eliminado');", true);
                    P_adi.Visible = false;
                    cargarGrid();
                }
            }
        }

        protected void btn_can_Click(object sender, System.EventArgs e)
        {
            txt_des.Text = "";
            txt_nom.Text = "";
            P_adi.Visible = false;
        }
    }
}