using System;
using System.Collections.Generic;

namespace AssignmentGroup_Repository.Models;

public partial class FuelType
{
    public int FuelTypeId { get; set; }

    public string FuelTypeName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
