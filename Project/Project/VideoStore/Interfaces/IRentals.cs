using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Model;

namespace VideoStore.Interfaces
{
    public interface IRentals
    {
        void AddRental(string movieTitle, string idNumber);
        void RemoveRental(string movieTitle, string idNumber);
        List<Rental> GetRentalsFor(string idNumber);
        List<Rental> GetRentalsForTitle(string movieTitle); //Extra

    }
}
