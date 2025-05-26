using System.Data.SqlTypes;

namespace LogIn_ADO.NET_Version.Data
{
    public class Conect
    {
        private string SQLChain = string.Empty;
        //Se crea el segundo constructor para los metodos alternos de conexión
        public Conect()
        {
            var Conecta = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            SQLChain = Conecta.GetSection("ConnectionStrings:SQLChain").Value;
        }
        //Luego de eso, permite regresar los valores
        public string GetSQLChain()
        {
            return SQLChain;
        }
    }
}
