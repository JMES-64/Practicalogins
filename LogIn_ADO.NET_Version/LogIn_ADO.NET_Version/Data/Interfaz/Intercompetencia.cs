using LogIn_ADO.NET_Version.Models;

namespace LogIn_ADO.NET_Version.Data.Interfaz
{
    public interface Intercompetencia
    {
        public Task<competencia> Buscador(int id);

       public Task<List<competencia>> ListaC(int id);
        // Define un método asíncrono que devuelve una lista de objetos 'competencia'
       
        public Task<competencia> CreaC(competencia com);
        // Define un método asíncrono para crear una nueva competencia

        public Task<competencia> EditC(competencia com);
    
    }
}
