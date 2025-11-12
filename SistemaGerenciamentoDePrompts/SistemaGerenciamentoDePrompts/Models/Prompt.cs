using System;

public class Prompt
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string Comando { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
}