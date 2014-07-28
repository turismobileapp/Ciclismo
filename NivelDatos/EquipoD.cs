using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace NivelDatos
{
    public class EquipoD : Conexion
    {
        private void reiniciar()
        {
            comando = new SqlCommand("Ciclistas", coneccion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("equiposID", SqlDbType.Decimal);
            comando.Parameters.Add("nombre", SqlDbType.NVarChar);
            comando.Parameters.Add("descripcion", SqlDbType.NVarChar);
            comando.Parameters.Add("op", SqlDbType.NVarChar);
            datatable = new DataTable();
        }

        public bool insertarEquipo(EquipoE e)
        {
            reiniciar();            
            comando.Parameters["equiposID"].Value = e.EquipoID;
            comando.Parameters["nombre"].Value = e.Nombre;
            comando.Parameters["descripcion"].Value = e.Descripcion;            
            comando.Parameters["op"].Value = '5';
            coneccion.Open();
            bool ret = true;
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                coneccion.Close();
            }
            return ret;
        }

        public bool actualizarEquipo(EquipoE e)
        {
            reiniciar();            
            comando.Parameters["equiposID"].Value = e.EquipoID;
            comando.Parameters["nombre"].Value = e.Nombre;
            comando.Parameters["descripcion"].Value = e.Descripcion;            
            comando.Parameters["op"].Value = '6';
            coneccion.Open();
            bool ret = true;
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                coneccion.Close();
            }
            return ret;
        }

        public bool eliminarEquipo(int equipoID)
        {
            try
            {
                reiniciar();
                comando.Parameters["equiposID"].Value = equipoID;
                comando.Parameters["op"].Value = '7';
                dataadapter = new SqlDataAdapter(comando);
                dataadapter.Fill(datatable);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool consultarEquipos()
        {
            try
            {
                reiniciar();
                comando.Parameters["op"].Value = '8';
                dataadapter = new SqlDataAdapter(comando);
                dataadapter.Fill(datatable);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
