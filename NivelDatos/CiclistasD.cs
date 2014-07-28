using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace NivelDatos
{
    public class CiclistasD : Conexion
    {
        private void reiniciar()
        {
            comando = new SqlCommand("Ciclistas", coneccion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("ciclistaID", SqlDbType.Decimal);
            comando.Parameters.Add("equiposID", SqlDbType.Decimal);
            comando.Parameters.Add("nombres", SqlDbType.NVarChar);
            comando.Parameters.Add("apellidos", SqlDbType.NVarChar);
            comando.Parameters.Add("edad", SqlDbType.Decimal);
            comando.Parameters.Add("op", SqlDbType.NVarChar);
            datatable = new DataTable();
        }

        public bool insertarCiclista(CiclistaE c)
        {
            reiniciar();
            comando.Parameters["ciclistaID"].Value = c.CiclistaID;
            comando.Parameters["equiposID"].Value = c.EquiposID;
            comando.Parameters["nombres"].Value = c.Nombres;
            comando.Parameters["apellidos"].Value = c.Apellidos;
            comando.Parameters["edad"].Value = c.Edad;
            comando.Parameters["op"].Value = '1';
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

        public bool actualizarCiclista(CiclistaE c)
        {
            reiniciar();
            comando.Parameters["ciclistaID"].Value = c.CiclistaID;
            comando.Parameters["equiposID"].Value = c.EquiposID;
            comando.Parameters["nombres"].Value = c.Nombres;
            comando.Parameters["apellidos"].Value = c.Apellidos;
            comando.Parameters["edad"].Value = c.Edad;
            comando.Parameters["op"].Value = '2';
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

        public bool eliminarCiclista(int ciclistaID)
        {
            try
            {
                reiniciar();
                comando.Parameters["ciclistaID"].Value = ciclistaID;
                comando.Parameters["op"].Value = '3';
                dataadapter = new SqlDataAdapter(comando);
                dataadapter.Fill(datatable);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool consultarCiclista()
        {
            try
            {
                reiniciar();                
                comando.Parameters["op"].Value = '4';
                dataadapter = new SqlDataAdapter(comando);
                dataadapter.Fill(datatable);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool consultarCiclistaMasJovenPorEquipo()
        {
            try
            {
                reiniciar();
                comando.Parameters["op"].Value = '9';
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
