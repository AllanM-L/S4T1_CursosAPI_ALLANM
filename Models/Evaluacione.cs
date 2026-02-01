using System;
using System.Collections.Generic;

namespace CursosAPI.Models;

public partial class Evaluacione
{
    public int Id { get; set; }

    public int? InscripcionId { get; set; }

    public decimal? Nota { get; set; }

    public string? Observacion { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Inscripcione? Inscripcion { get; set; }
}
