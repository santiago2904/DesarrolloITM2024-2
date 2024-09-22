namespace TallerDesarrollo.models;

public class Cliente : Persona
{
    public decimal Credito { get; set; }

    // Clave foránea
    public int EmpresaCodigo { get; set; }
    public Empresa? Empresa { get; set; } // Relación opcional, no debes agregarla al contexto

    public Cliente(string? email = null, string? nombre = null, string? apellido = null, decimal credito = 0)
        : base(email, nombre, apellido)
    {
        Credito = credito;
    }
}