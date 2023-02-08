using System;
using System.Collections.Generic;

namespace WebServicesEmpresaX.Model;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Direccione> Direcciones { get; } = new List<Direccione>();
}
