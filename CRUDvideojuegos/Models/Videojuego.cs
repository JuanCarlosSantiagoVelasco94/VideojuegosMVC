using System;
using System.Collections.Generic;

namespace CRUDvideojuegos.Models;

public partial class Videojuego
{
    public int IdVideojuego { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaLanzamiento { get; set; }

    public int Calificacion { get; set; }

    public int GeneroId { get; set; }

    public int ConsolaId { get; set; }
}
