namespace TallerDesarrollo.models;
//En este caso, agrupa la clase Persona bajo TallerDesarrollo.models. Esto ayuda a organizar el código y evitar conflictos de nombres en otros archivos.

public class Vendedor : Persona
{
    public Vendedor(string? direccion = null, string? carne = null, string? email = null,
        string? nombre = null, string? apellido = null)
        : base(email, nombre, apellido)
    {
        Direccion = direccion;
        Carne = carne;
    }

    public string? Direccion { get; set; }
    public string? Carne { get; set; }
}