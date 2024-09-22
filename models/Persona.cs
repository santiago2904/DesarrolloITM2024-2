using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models;

public class Persona
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }

    private string? _email;
    private string? _nombre;
    private string? _apellido;

    public Persona( string? email = null, string? nombre = null, string? apellido = null)
    {
        Email = email;
        Nombre = nombre;
        Apellido = apellido;
    }

    // Getter y setter para Email
    public string? Email { get; set; }

    // Getter y setter para Nombre
    public string? Nombre { get; set; }
    // Getter y setter para Apellido
    public string? Apellido { get; set; } 
}