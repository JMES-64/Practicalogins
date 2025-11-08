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
        [RegularExpression("0-100")]
        [Required(ErrorMessage = "El valor debe ser de 0 a 100")]
        public int Competencia { get; set; }
        //Nivel de competencia, va del 0 al 100
       public int IDU { get; set; }
        //ID del usuario al que la competencia está ligada
    }
}
