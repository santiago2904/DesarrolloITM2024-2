using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models;

public class Persona
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    
    public string? Email { get; set; }
    
    public string? Nombre { get; set; }
    
    public string? Apellido { get; set; }

    public Persona(string? email = null, string? nombre = null, string? apellido = null)
    {
        Email = email;
        Nombre = nombre;
        Apellido = apellido;
    }
}