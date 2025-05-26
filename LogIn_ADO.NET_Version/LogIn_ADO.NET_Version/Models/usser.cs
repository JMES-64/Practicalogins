namespace LogIn_ADO.NET_Version.Models
{
    public class usser
    {
      public  int IDU { get; set; }
        //ID del usuario
        public string Nombre { get; set; }
        //Nombre del usuario
        public string Correo { get; set; }
        //Correo del usuario
        public string Pass { get; set; }
        //Contraseña del usuario
        public int Adm { get; set; }
        //Administrador del sistema, debe ser 0 o 1
        public int Own { get; set; }
        //Propietario del sistema, debe ser 0 o 1

    }
}
