using LogIn_ADO.NET_Version.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO.Pipelines;
using System.Runtime.ConstrainedExecution;
using static LogIn_ADO.NET_Version.Data.Service.ServiceUsser;

namespace LogIn_ADO.NET_Version.Data.Service
{
    public class Servicecompetencia : Interfaz.Intercompetencia
    {

        public async Task<competencia> Buscador(int id)
        {
            var connector = new Conect();
            //Otorga una variable a la función
            competencia comp = new competencia();
            // Crea un objeto 'competencia' para almacenar el usuario encontrado
            try
            {
                using (var connection = new SqlConnection(connector.GetSQLChain()))
                {
                    // Crea una conexión a la base de datos usando la cadena de conexión  
                    var oComando = new SqlCommand("BuscarC", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                        // Especifica que el comando es un procedimiento almacenado
                    };
                    oComando.Parameters.AddWithValue("@IDC", id);
                    await connection.OpenAsync();
                    // Abre la conexión de forma asíncrona
                    await using (var oReader = await oComando.ExecuteReaderAsync())
                    {
                        while (await oReader.ReadAsync())
                        {
                            comp.IDC = Convert.ToInt32(oReader["IDC"]);
                            comp.Nombre_C = oReader["Nombre_C"]?.ToString() ?? string.Empty; // Manejo de referencia nula  
                            comp.Competencia = Convert.ToInt32(oReader["Comp"]);
                            comp.IDU = Convert.ToInt32(oReader["IDU"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return comp; // Retorna el objeto 'competencia' vacío en caso de error
            }
            return comp;
        }

        public async Task<List<competencia>> ListaC(int id)
        {
            var connector = new Conect();
            // Crea una instancia de la clase Conect para establecer la conexión a la base de datos
            var lista = new List<competencia>();
            // Crea una lista vacía de objetos 'competencia'
           
            try
            {
                using (var con = new SqlConnection(connector.GetSQLChain()))
                {
                    // Establece la conexión a la base de datos utilizando la cadena de conexión obtenida
                    var oComando = new SqlCommand("ListarC", con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                        // Configura el comando para llamar al procedimiento almacenado 'ListarC'
                    };
                    await con.OpenAsync();
                    // Abre la conexión de forma asíncrona
                    oComando.Parameters.Add(new SqlParameter("@IDU", id));
                    // Agrega un parámetro al comando para pasar el ID del usuario
                    
                    await using (var reader = await oComando.ExecuteReaderAsync())
                    {
                     
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new competencia
                            {
                                IDC = Convert.ToInt32(reader["IDC"]),
                                Nombre_C = reader["Nombre_C"].ToString(),
                                Competencia = Convert.ToInt32(reader["Comp"]),
                                IDU = Convert.ToInt32(reader["IDU"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return lista; // Retorna la lista vacía en caso de error
            }
            return lista; // Retorna la lista de competencias obtenidas
        }

        public async Task<competencia> CreaC(competencia com) { 
        var connector = new Conect();
            //Otorga una variable a la función
            using (var connection = new SqlConnection(connector.GetSQLChain())) 
            {
                //Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("RegistraC", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                    // Especifica que el comando es un procedimiento almacenado
                };
                oComando.Parameters.AddWithValue("@Nombre_C", com.Nombre_C);
                oComando.Parameters.AddWithValue("@Comp", com.Competencia);
                oComando.Parameters.AddWithValue("@IDU", com.IDU);
                // Agrega los parámetros necesarios para el procedimiento almacenado
                await connection.OpenAsync();
                // Abre la conexión de forma asíncrona
                await oComando.ExecuteNonQueryAsync();
                // Ejecuta el comando de forma asíncrona
            }

            return com; // Retorna el objeto 'competencia' creado

        }

        public async Task<competencia> EditC(competencia com)
        {
            var connector = new Conect();
            //Otorga una variable a la función
            using (var connection = new SqlConnection(connector.GetSQLChain()))
            {
                // Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("EditaC", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                    // Especifica que el comando es un procedimiento almacenado
                };
                oComando.Parameters.AddWithValue("@IDC", com.IDC);
                oComando.Parameters.AddWithValue("@Nombre_C", com.Nombre_C);
                oComando.Parameters.AddWithValue("@Comp", com.Competencia);
                await connection.OpenAsync();
                // Abre la conexión de forma asíncrona
                await oComando.ExecuteNonQueryAsync();
                // Ejecuta el comando de forma asíncrona
            }
            return com; // Retorna el objeto 'competencia' editado
        }
    }
}
