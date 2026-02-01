using System;
using System.Collections.Generic;

namespace CursosAPI.Models;

public partial class Profesore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Especialidad { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
