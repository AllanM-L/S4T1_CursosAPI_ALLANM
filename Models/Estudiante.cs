using System;
using System.Collections.Generic;

namespace CursosAPI.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
