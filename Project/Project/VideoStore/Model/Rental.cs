using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Model
{
    public class Rental
    {
        public string MovieTitle { get; set; }
        public string CustomerId { get; set; }
        public DateTime RentedAt { get; set; }
        public DateTime DueDate => RentedAt.AddDays(3);
    }
}
