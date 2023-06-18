using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace movieproject.Models
{
    public class RentalHeader
    {
        [Key]
        public int RentalNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }

        // Other properties and relationships

        public Customer Customer { get; set; }
        public List<RentalDetail> RentalDetails { get; set; }
    }
}