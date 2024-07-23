using System;
using System.Collections.Generic;

namespace AssignmentGroup_Repository.Models;

public partial class SellerType
{
    public int SellerTypeId { get; set; }

    public string SellerTypeName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
