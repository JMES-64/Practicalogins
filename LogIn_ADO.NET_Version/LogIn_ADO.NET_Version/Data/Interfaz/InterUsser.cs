using LogIn_ADO.NET_Version.Models;

namespace LogIn_ADO.NET_Version.Data.Interfaz
{
    public interface InterUsser
    {
        public Task<usser> Buscador(int Id);
        // Define un método asíncrono que busca un usuario por su ID y devuelve un objeto 'usser'
        public Task<List<usser>> ListaU();
        // Define un método asíncrono que devuelve una lista de objetos 'usser'
        public Task<List<usser>> ListaAU();
        Task<usser> CreateU(usser cuser);
        // Define un método asíncrono que crea un nuevo usuario y devuelve el objeto 'usser' creado
        Task<usser> CreateAU(usser cuser);
        // Define un método asíncrono que crea un nuevo usuario administrador y devuelve el objeto 'usser' creado
        Task<usser> EditU(usser cuser);
        // Define un método asíncrono que actualiza un usuario existente y devuelve el objeto 'usser' actualizado

    }
}
