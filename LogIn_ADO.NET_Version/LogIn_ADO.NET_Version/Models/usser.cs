using System.ComponentModel.DataAnnotations;

namespace LogIn_ADO.NET_Version.Models
{
    public class usser
    {
        [Key]
        public  int IDU { get; set; }
        //ID del usuario

        [Required(ErrorMessage = "Se necesita un nombre.")]
        public string Nombre { get; set; }
        //Nombre del usuario

        [Required(ErrorMessage = "Se necesita un correo.")]
        [RegularExpression("^([a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5})$", ErrorMessage = "Formato erroneo")]
        public string Correo { get; set; }
        //Correo del usuario
        [Required(ErrorMessage = "Se necesita una contraseña.")]
        public string Pass { get; set; }
        //Contraseña del usuario
        public int Adm { get; set; }
        //Administrador del sistema, debe ser 0 o 1
        public int Own { get; set; }
        //Propietario del sistema, debe ser 0 o 1

    }
}
