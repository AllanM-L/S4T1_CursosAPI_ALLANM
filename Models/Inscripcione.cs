using System;
using System.Collections.Generic;

namespace CursosAPI.Models;

public partial class Inscripcione
{
    public int Id { get; set; }

    public int? EstudianteId { get; set; }

    public int? CursoId { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Estado { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();
}
