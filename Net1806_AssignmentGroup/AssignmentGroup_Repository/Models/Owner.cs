using System;
using System.Collections.Generic;

namespace AssignmentGroup_Repository.Models;

public partial class Owner
{
    public int OwnerId { get; set; }
    public string OwnerType { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
