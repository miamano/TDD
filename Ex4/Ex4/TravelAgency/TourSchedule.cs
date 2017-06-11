using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule : ITourSchedule
    {
        private Dictionary<DateTime, List<Tour>> tours;

        public TourSchedule()
        {
            tours = new Dictionary<DateTime, List<Tour>>();
        }

        public List<Tour> GetToursFor(DateTime when)
        {
            return tours[when.Date];
        }

        public void CreateTour(string name, DateTime when, int seat)
        {
            if (!tours.ContainsKey(when.Date))
                tours.Add(when.Date, new List<Tour>());

            if (GetToursFor(when).Count < 3)
                tours[when.Date].Add(new Tour(name, when, seat));
            else
                throw new TourAllocationException();
        }
    }
}
