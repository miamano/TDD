using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Exceptions;
using VideoStore.Interfaces;
using VideoStore.Model;

namespace VideoStore.BL
{
    public class Rentals : IRentals
    {
        private const int MaxCopiesOfMovies = 3;
        private List<Rental> rentals;

        public Rentals()
        {
            rentals = new List<Rental>();
        }

        public void AddRental(string movieTitle, string idNumber)
        {
            var rentalsForCustomer = GetRentalsFor(idNumber);

            var dueDayRentalForCustomer = rentalsForCustomer.Where(r => r.DueDate < DateTime.Now).ToList();

            if (dueDayRentalForCustomer.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Late returns:");
                foreach (var item in dueDayRentalForCustomer)
                    sb.AppendLine("Title:" + item.MovieTitle + ", Due Date: " + item.DueDate.Date );

                throw new NoMoreCopiesToRentException(sb.ToString());
            }

            if (rentalsForCustomer.Count() >= MaxCopiesOfMovies)
                throw new NoMoreCopiesToRentException($"Max. {MaxCopiesOfMovies} movies per customer.");

            if (rentalsForCustomer.Any(r => r.CustomerId == idNumber))
                throw new NoMoreCopiesToRentException("This movie has already rented by same customer.");

            var tmpRentedAt = new DateTime();
            rentals.Add(new Rental() { CustomerId = idNumber, MovieTitle = movieTitle, RentedAt = tmpRentedAt.Date });
        }

        public List<Rental> GetRentalsFor(string idNumber)
        {
            return rentals.Where(r => r.CustomerId == idNumber).ToList();
        }

        public List<Rental> GetRentalsForTitle(string movieTitle)
        {
            return rentals.Where(r => r.MovieTitle == movieTitle).ToList();
        }

        public void RemoveRental(string movieTitle, string idNumber)
        {
            var rent = rentals.Where(r => r.CustomerId == idNumber && r.MovieTitle == movieTitle).FirstOrDefault();
            if (rent != null)
                rentals.Remove(rent);
        }
    }
}
