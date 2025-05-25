namespace LogIn_ADO.NET_Version.Models
{
    public class competencia
    {
        int IDC { get; set; }
        //ID de la competencia
        string Nombre_C { get; set; }
        //Nombre de la competencia
        int Competencia { get; set; }
        //Nivel de competencia, va del 1 al 5
        int IDU { get; set; }
        //ID del usuario al que la competencia está ligada
    }
}
