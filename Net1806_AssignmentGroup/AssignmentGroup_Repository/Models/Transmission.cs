using System;
using System.Collections.Generic;

namespace AssignmentGroup_Repository.Models;

public partial class Transmission
{
    public int TransmissionId { get; set; }

    public string TransmissionType { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
