using LogIn_ADO.NET_Version.Models;

namespace LogIn_ADO.NET_Version.Data.Interfaz
{
    public interface InterUsser
    {
        public Task<List<usser>> ListaU();
    }
}
