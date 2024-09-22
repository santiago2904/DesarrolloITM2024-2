using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerDesarrollo.models;

public class Empresa
{
    public Empresa(string? nombre = null)
    {
        Nombre = nombre;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }

    public string? Nombre { get; set; }
}