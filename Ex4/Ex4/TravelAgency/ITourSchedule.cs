using System;
using System.Collections.Generic;

namespace TravelAgency
{
    public interface ITourSchedule
    {
        void CreateTour(string name, DateTime when, int seat);
        List<Tour> GetToursFor(DateTime when);
    }
}