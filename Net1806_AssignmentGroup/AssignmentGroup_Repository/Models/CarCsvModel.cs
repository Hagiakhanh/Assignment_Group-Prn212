using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGroup_Repository.Models
{
    public class CarCsvModel
    {
        public string Car_Name { get; set; }
        public int Year { get; set; }
        public double Selling_Price { get; set; }
        public double Present_Price { get; set; }
        public int Kms_Driven { get; set; }
        public string Fuel_Type { get; set; }
        public string Seller_Type { get; set; }
        public string Transmission { get; set; }
        public string Owner { get; set; }
    }
}
