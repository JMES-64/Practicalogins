namespace LogIn_ADO.NET_Version.Models
{
    public class usser
    {
        int IDU { get; set; }
        //ID del usuario
        string Nombre { get; set; }
        //Nombre del usuario
        string Correo { get; set; }
        //Correo del usuario
        string Pass { get; set; }
        //Contraseña del usuario
        int Adm { get; set; }
        //Administrador del sistema, debe ser 0 o 1
        int Own { get; set; }
        //Propietario del sistema, debe ser 0 o 1

    }
}
