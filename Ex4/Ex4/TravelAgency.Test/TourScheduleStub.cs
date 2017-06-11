using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Test
{
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { get; set; }

        public void CreateTour(string name, DateTime when, int seat)
        {
            Tours.Add(new Tour(name, when, seat));
        }

        //TODO
        public List<Tour> GetToursFor(DateTime when)
        {
            return Tours;
        }
    }
}
