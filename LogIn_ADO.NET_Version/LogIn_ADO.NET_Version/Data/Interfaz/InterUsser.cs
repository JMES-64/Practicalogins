using LogIn_ADO.NET_Version.Models;

namespace LogIn_ADO.NET_Version.Data.Interfaz
{
    public interface InterUsser
    {

        public Task<usser> LogIn(string email, string password);
        //Define un método asíncrono que buscará al usuario basado en el email y la contraseña; debe devolver el objeto 'usser'
        public Task<usser> Buscador(int Id);
        // Define un método asíncrono que busca un usuario por su ID y devuelve un objeto 'usser'
        public Task<List<usser>> ListaU();
        // Define un método asíncrono que devuelve una lista de objetos 'usser'
        public Task<List<usser>> ListaAU();
        public Task<usser> CreateU(usser cuser);
        // Define un método asíncrono que crea un nuevo usuario y devuelve el objeto 'usser' creado
        public Task<usser> CreateAU(usser cuser);
        // Define un método asíncrono que crea un nuevo usuario administrador y devuelve el objeto 'usser' creado
        public Task<usser> EditU(usser cuser);
        // Define un método asíncrono que actualiza un usuario existente y devuelve el objeto 'usser' actualizado
        public Task<usser> EditAU(usser cuser);
        // Define un método asíncrono que actualiza un usuario administrador existente y devuelve el objeto 'usser' actualizado
        public Task<usser> Borra(int Id);
        // Define un método asíncrono que elimina un usuario por su ID y devuelve el objeto 'usser' eliminado

    }
}
