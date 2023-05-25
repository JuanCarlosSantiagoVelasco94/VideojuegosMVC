using System;
using System.Collections.Generic;

namespace CRUDvideojuegos.Models;

public partial class Consola
{
    public int IdConsola { get; set; }

    public string NombreConsola { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public DateTime FechaReg { get; set; }
}
