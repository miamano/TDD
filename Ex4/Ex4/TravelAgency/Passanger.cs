using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Passenger(string lastName, string firstName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
