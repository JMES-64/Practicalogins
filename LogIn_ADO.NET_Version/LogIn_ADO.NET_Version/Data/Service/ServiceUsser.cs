using LogIn_ADO.NET_Version.Models;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace LogIn_ADO.NET_Version.Data.Service
{
    public class ServiceUsser : Interfaz.InterUsser
    {

        public async Task<usser> LogIn(string email, string password) {
            var connector = new Conect();
            //Otorga la cariable a la función
            usser user = new usser();
            //Crea un objeto 'usser' para almacenar el usuario encontrado
            try
            {
                using (var connection = new SqlConnection(connector.GetSQLChain()))
                {
                    //Crea la conexión en la base de datos con la cadena de conexión
                    var oComando = new SqlCommand("Log_In", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                        //Es´pecifica que el comando es un procedimieto almacenado
                    };
                    oComando.Parameters.AddWithValue("@Correo", email);
                    oComando.Parameters.AddWithValue("@Pass", Encrypt.EncryptPassword(password));
                    //Los comandos que se van a ingresar para la consulta en la BD
                    await connection.OpenAsync();
                    // Abre la conexión de forma asíncrona
                    await using (var oReader = await oComando.ExecuteReaderAsync())
                    {
                        while (await oReader.ReadAsync())
                        {
                            user.IDU = Convert.ToInt32(oReader["IDU"]);
                            user.Nombre = oReader["Nombre"]?.ToString() ?? string.Empty; // Manejo de referencia nula  
                            user.Correo = oReader["Correo"]?.ToString() ?? string.Empty; // Manejo de referencia nula 
                            user.Pass = oReader["Pass"]?.ToString() ?? string.Empty;
                            user.Adm = Convert.ToInt32(oReader["Adm"]);
                            user.Own = Convert.ToInt32(oReader["Own"]);
                        }
                        /*
                        Tiene que tomar todos los datos del usuario para verificar que se trata del usuario correcto
                        además de verificar que tenga los permisos correctos
                        */  
                    }
                }
            }
            catch (Exception ex)
            {
                return user; // Retorna el objeto 'usser' vacío en caso de error
            }
            return user;
        }

        public async Task<usser> Buscador(int Id) { 
        var connector = new Conect();
            //Otorga una variable a la función
            usser user = new usser();
            // Crea un objeto 'usser' para almacenar el usuario encontrado
            try
            {
                using (var connection = new SqlConnection(connector.GetSQLChain()))
                {
                    // Crea una conexión a la base de datos usando la cadena de conexión  
                    var oComando = new SqlCommand("Buscar", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                        // Especifica que el comando es un procedimiento almacenado
                    };
                    oComando.Parameters.AddWithValue("@IDU", Id);
                    await connection.OpenAsync();
                    // Abre la conexión de forma asíncrona
                    await using (var oReader = await oComando.ExecuteReaderAsync())
                    {
                        while (await oReader.ReadAsync())
                        {
                            user.IDU = Convert.ToInt32(oReader["IDU"]);
                            user.Nombre = oReader["Nombre"]?.ToString() ?? string.Empty; // Manejo de referencia nula  
                            user.Correo = oReader["Correo"]?.ToString() ?? string.Empty; // Manejo de referencia nula  
                            user.Adm = Convert.ToInt32(oReader["Adm"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return user; // Retorna el objeto 'usser' vacío en caso de error
            }
            return user;
        }

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
            catch (Exception ex)
            {
                return lista; // Retorna la lista vacía en caso de error
            }
            return lista;
        }

        public async Task<List<usser>> ListaAU()
        {
            var connector = new Conect();
            //Otorga una variable a la función
            var lista = new List<usser>();
            // Crea una lista donde almacenar los usuarios y admins

            try
            {

                var connection = new SqlConnection(connector.GetSQLChain());
                // Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("ListarAU", connection)
                {
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
                            Correo = oReader["Correo"]?.ToString() ?? string.Empty, // Manejo de referencia nula  
                            Adm = Convert.ToInt32(oReader["Adm"]),
                        });

                    }
                }

            }
            catch (Exception ex)
            {
                return lista; // Retorna la lista vacía en caso de error

            }
            return lista;

        }

        public async Task<usser> CreateU(usser cuser)
        {

            var connector = new Conect();
            //Otorga una variable a la función
            using (var connection = new SqlConnection(connector.GetSQLChain()))
            {
                // Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("RegistraU", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                    // Especifica que el comando es un procedimiento almacenado
                };
                oComando.Parameters.AddWithValue("@Nombre", cuser.Nombre);
                oComando.Parameters.AddWithValue("@Correo", cuser.Correo);
                oComando.Parameters.AddWithValue("@Pass", Encrypt.EncryptPassword(cuser.Pass));
                oComando.Parameters.AddWithValue("@Adm", 0);
                oComando.Parameters.AddWithValue("@Own", 0);
                // Agrega los parámetros necesarios para el procedimiento almacenado
                await connection.OpenAsync();
                // Abre la conexión de forma asíncrona
                await oComando.ExecuteNonQueryAsync();
                // Ejecuta el comando de forma asíncrona
            }

            return cuser; // Retorna el objeto 'usser' creado
        }

        public async Task<usser> CreateAU(usser cuser)
        {
            var connector = new Conect();
            //Otorga una variable a la función
            using (var connection = new SqlConnection(connector.GetSQLChain()))
            {
                // Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("RegistraAU", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                    // Especifica que el comando es un procedimiento almacenado
                };
                oComando.Parameters.AddWithValue("@Nombre", cuser.Nombre);
                oComando.Parameters.AddWithValue("@Correo", cuser.Correo);
                oComando.Parameters.AddWithValue("@Pass", Encrypt.EncryptPassword(cuser.Pass));
                oComando.Parameters.AddWithValue("@Adm", cuser.Adm);
                oComando.Parameters.AddWithValue("@Own", 0);
                // Agrega los parámetros necesarios para el procedimiento almacenado
                await connection.OpenAsync();
                // Abre la conexión de forma asíncrona
                await oComando.ExecuteNonQueryAsync();
                // Ejecuta el comando de forma asíncrona
            }
            return cuser; // Retorna el objeto 'usser' creado
        }


        public async Task<usser> EditU(usser cuser)
        {
            var connector = new Conect();
            //Otorga una variable a la función
            using (var connection = new SqlConnection(connector.GetSQLChain()))
            {
                // Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("EditaU", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                    // Especifica que el comando es un procedimiento almacenado
                };
                oComando.Parameters.AddWithValue("@IDU", cuser.IDU);
                oComando.Parameters.AddWithValue("@Nombre", cuser.Nombre);
                oComando.Parameters.AddWithValue("@Correo", cuser.Correo);
                await connection.OpenAsync();
                // Abre la conexión de forma asíncrona
                await oComando.ExecuteNonQueryAsync();
                // Ejecuta el comando de forma asíncrona
            }
            return cuser; // Retorna el objeto 'usser' editado
        }

        public async Task<usser> EditAU(usser cuser)
        {
            var connector = new Conect();
            //Otorga una variable a la función
            using (var connection = new SqlConnection(connector.GetSQLChain()))
            {
                // Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("EditaAU", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                    // Especifica que el comando es un procedimiento almacenado
                };
                oComando.Parameters.AddWithValue("@IDU", cuser.IDU);
                oComando.Parameters.AddWithValue("@Nombre", cuser.Nombre);
                oComando.Parameters.AddWithValue("@Correo", cuser.Correo);
                oComando.Parameters.AddWithValue("@Adm", cuser.Adm);
                await connection.OpenAsync();
                // Abre la conexión de forma asíncrona
                await oComando.ExecuteNonQueryAsync();
                // Ejecuta el comando de forma asíncrona
            }
            return cuser; // Retorna el objeto 'usser' editado
        }


        public async Task<usser> Borra(int Id)
        {
            var connector = new Conect();
            //Otorga una variable a la función
            
            using (var connection = new SqlConnection(connector.GetSQLChain()))
            {
                // Crea una conexión a la base de datos usando la cadena de conexión
                var oComando = new SqlCommand("Elimina", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                    // Especifica que el comando es un procedimiento almacenado
                };
                oComando.Parameters.AddWithValue("@IDU", Id);
                await connection.OpenAsync();
                // Abre la conexión de forma asíncrona
                await oComando.ExecuteNonQueryAsync();
                // Ejecuta el comando de forma asíncrona
            }
            return new usser { IDU = Id }; // Retorna un objeto 'usser' con el ID del usuario eliminado
        }



        public class Encrypt()
        {
            // Clase para manejar la encriptación de contraseñas
            public static string EncryptPassword(string password)
            {
                // Simplifica la creación de la instancia de SHA256
                byte[] stream = SHA256.HashData(Encoding.ASCII.GetBytes(password));
                // Elimina la asignación innecesaria de "encoding"
                StringBuilder sb = new();
                // Crea un StringBuilder para construir la contraseña encriptada
                for (int i = 0; i < stream.Length; i++)
                {
                    sb.AppendFormat("{0:X2}", stream[i]);
                }
                return sb.ToString(); // Retorna la contraseña encriptada
            }
        }

    }
    
}
