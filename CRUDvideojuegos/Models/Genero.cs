using System;
using System.Collections.Generic;

namespace CRUDvideojuegos.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string NombreGenero { get; set; } = null!;
    //public string NombreGenero { get; set; }

    public DateTime FechaRegistro { get; set; }
}
