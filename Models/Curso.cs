using System;
using System.Collections.Generic;

namespace CursosAPI.Models;

public partial class Curso
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Duracion { get; set; }

    public int? ProfesorId { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual Profesore? Profesor { get; set; }
}
