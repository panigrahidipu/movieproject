using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movieproject.Models
{
    public class RentalDetail
    {
        public int Id { get; set; }
        public int RentalHeaderId { get; set; }
        public int MovieId { get; set; }
        public DateTime? DateReturned { get; set; }
        

        public virtual RentalHeader RentalHeader { get; set; }
        public virtual Movie Movie { get; set; }
    }
}