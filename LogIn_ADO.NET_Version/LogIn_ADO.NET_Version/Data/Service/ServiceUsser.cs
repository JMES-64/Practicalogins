using LogIn_ADO.NET_Version.Models;
using System.ComponentModel;
using Microsoft.Data.SqlClient;

namespace LogIn_ADO.NET_Version.Data.Service
{
    public class ServiceUsser : Interfaz.InterUsser
    {

        public async Task<List<usser>> ListaU()
        {
            var connector = new Conect();
            //Otorga una variable a la función
            var lista = new List<usser>();
            // Crea una lista donde almacenar los usuarios 

            try
            {
                using (var connection = new SqlConnection(connector.GetSQLChain()))
                {
                    // Crea una conexión a la base de datos usando la cadena de conexión  
                    var oComando = new SqlCommand("ListarU", connection)
                    {
                        // Especifica que el comando es un procedimiento almacenado
                        CommandType = System.Data.CommandType.StoredProcedure
                        // Especifica que el comando es un procedimiento almacenado

                    };
                    await connection.OpenAsync();
                    // Abre la conexión de forma asíncrona
                    await using (var oReader = await oComando.ExecuteReaderAsync())
                    {
                        while (await oReader.ReadAsync())
                        {
                            lista.Add(new usser
                            {
                                IDU = Convert.ToInt32(oReader["IDU"]),
                                Nombre = oReader["Nombre"]?.ToString() ?? string.Empty, // Manejo de referencia nula  
                                Correo = oReader["Correo"]?.ToString() ?? string.Empty  // Manejo de referencia nula  
                            });
                        }
                    }

                }
            }
            catch (Exception ex) {
                return lista; // Retorna la lista vacía en caso de error
            }
            return lista;
        }


    }

    
}
