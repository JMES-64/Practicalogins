using System.ComponentModel.DataAnnotations;

namespace LogIn_ADO.NET_Version.Models
{
    public class competencia
    {
        [Key]
       public int IDC { get; set; }
        //ID de la competencia
        [Required(ErrorMessage = "El nombre de la competencia es necesario.")]
       public  string Nombre_C { get; set; }
        //Nombre de la competencia
       public int Competencia { get; set; }
        //Nivel de competencia, va del 1 al 5
       public int IDU { get; set; }
        //ID del usuario al que la competencia está ligada
    }
}
