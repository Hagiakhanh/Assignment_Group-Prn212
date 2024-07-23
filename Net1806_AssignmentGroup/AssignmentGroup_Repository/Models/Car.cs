using System;
using System.Collections.Generic;

namespace AssignmentGroup_Repository.Models;

public partial class Car
{
    public int CarId { get; set; }

    public int Year { get; set; }

    public decimal SellingPrice { get; set; }

    public decimal PresentPrice { get; set; }

    public int KmsDriven { get; set; }

    public int? FuelTypeId { get; set; }

    public int? SellerTypeId { get; set; }

    public int? TransmissionId { get; set; }

    public int? OwnerId { get; set; }

    public virtual FuelType? FuelType { get; set; }

    public virtual Owner? Owner { get; set; }

    public virtual SellerType? SellerType { get; set; }

    public virtual Transmission? Transmission { get; set; }
}
