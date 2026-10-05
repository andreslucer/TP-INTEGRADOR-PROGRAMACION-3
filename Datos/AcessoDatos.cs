using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    
    public class AcessoDatos
    {
        private string CadenaConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=TPIntegradorGrupo15;Integrated Security=True;";

        public AcessoDatos() 
        {
            
        }
        private SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private SqlDataAdapter ObtenerAdaptador(string consultaSql, SqlConnection conexion)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, conexion);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int EjercutarConsulta(SqlCommand comando)
        {
            int filasAfectadas = 0;
            SqlConnection conexion = ObtenerConexion();

            try
            {
                if (conexion != null)
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex){
                throw ex;
            }

            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return filasAfectadas;
        }

        public int ObtenerEscalar(SqlCommand comando)
        {
            int resultado = 0;
            SqlConnection conexion = ObtenerConexion();

            try
            {
                if (conexion != null)
                {
                    // Le asignamos la conexión abierta al comando
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;

                    // ExecuteScalar devuelve la primera columna de la primera fila como 'object'
                    object valorDevuelto = comando.ExecuteScalar();

                    // Verificamos que no sea nulo ni nulo de base de datos
                    if (valorDevuelto != null && valorDevuelto != DBNull.Value)
                    {
                        // Convertimos ese 'object' a un 'int' de C#
                        resultado = Convert.ToInt32(valorDevuelto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; // O manejar el error según tu arquitectura
            }
            finally
            {
                // Nos aseguramos de cerrar la conexión siempre
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resultado;
        }
        public DataTable ObtenerTabla(string NombreTabla, String sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = ObtenerConexion();
            SqlDataAdapter adapter = ObtenerAdaptador(sql, conexion);
            adapter.Fill(ds, NombreTabla);
            conexion.Close();
            return ds.Tables[NombreTabla];

        }
        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            SqlConnection connection = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, connection);
            SqlDataReader datos = cmd.ExecuteReader();

            if (datos.Read())
            {
                // 1. Verificamos que la celda devuelta por SQL no sea NULL
                if (datos[0] != DBNull.Value)
                {
                    // 2. Intentamos convertir el dato a entero de forma segura
                    string valorBd = datos[0].ToString();

                    if (int.TryParse(valorBd, out int resultado))
                    {
                        // Si la conversión es exitosa, guardamos el número
                        max = resultado;
                    }
                    else
                    {
                        // Si el dato era texto o algo que no se puede convertir, queda en 0
                        max = 0;
                    }
                }
            }

            // Cerramos las conexiones
            datos.Close();
            connection.Close();

            return max;
        }


    }   
}
