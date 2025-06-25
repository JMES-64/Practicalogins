using LogIn_ADO.NET_Version.Models;

namespace LogIn_ADO.NET_Version.Data.Interfaz
{
    public interface Intercompetencia
    {
       public Task<List<competencia>> ListaC(int id);
        // Define un método asíncrono que devuelve una lista de objetos 'competencia'
    }
}
