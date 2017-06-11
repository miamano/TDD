using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Tour
    {
        public string Name { get; set; }

        public DateTime When { get; set; }

        public int Seat { get; set; }

        public Tour(string name, DateTime when, int seat)
        {
            Name = name;
            When = when;
            Seat = seat;
        }
    }
}
