using AssignmentGroup_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGroup_Repository.ModelsView
{
    public class CarView
    {
        public int CarId { get; set; }

        public int Year { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal PresentPrice { get; set; }

        public int KmsDriven { get; set; }

        public string? FuelTypeName { get; set; }

        public string? Owner { get; set; }

        public string? SellerTypeName { get; set; }

        public string? TransmissionName { get; set; }
    }
}
