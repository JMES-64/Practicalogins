using LogIn_ADO.NET_Version.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO.Pipelines;

namespace LogIn_ADO.NET_Version.Data.Service
{
    public class Servicecompetencia : Interfaz.Intercompetencia
    {

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
    }
}