using System;
using System.Collections.Generic;

namespace WebServicesEmpresaX.Model;

public partial class Direccione
{
    public int DireccionId { get; set; }

    public string Calle { get; set; } = null!;

    public string Sector { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
