using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using VideoStore.Exceptions;
using VideoStore.Interfaces;
using VideoStore.Model;

namespace VideoStore.BL
{
    public class VideoStoreClass : IVideoStore
    {
        private const int MaxCopiesOfMovies = 3;

        private List<Movie> movies;
        private List<Customer> customers;
        private IRentals rentals;

        public VideoStoreClass(IRentals rentals)
        {
            movies = new List<Movie>();
            customers = new List<Customer>();
            this.rentals = rentals;
        }

        public void AddMovie(Movie movie)
        {
            if(movie.Year < 1900 && movie.Year > 2017)
                throw new NotValidYearException("Not valid year.");

            var films = movies.Where(m => m.Title == movie.Title && m.Year == movie.Year && m.Genre == movie.Genre);

            if (films == null || films.Count() < MaxCopiesOfMovies)
                movies.Add(movie);
            else
                throw new TooManyCopiesOfSameMovieException("Max. " + MaxCopiesOfMovies + " copies are allowed.");
        }

        public List<Customer> GetCustomer()
        {
            return customers;
        }

        public void RegisterCustomer(string name, string idNumber)
        {
            CheckIDFormat(idNumber);

            //TODO: CompareTo or operator overloading in Customer
            var cust = customers.Where(c => c.Name == name && c.IdNumber == idNumber);
            if (cust == null || cust.Count() == 0)
                customers.Add(new Customer(name, idNumber));
            else
                throw new RegistratedCustomerException("Customer is already in the system.");
        }

        public void RentMovie(string movieTitle, string idNumber)
        {
            if(string.IsNullOrEmpty(movieTitle) || string.IsNullOrWhiteSpace(movieTitle))
                throw new EmptyMovieTitleException("Missing title.");

            CheckIDFormat(idNumber);

            var films = movies.Where(m => m.Title == movieTitle);
            if (films == null || films.Count() == 0)
                throw new NotRegistratedMovieException("Movie is not in the store.");

            var cust = customers.Where(c => c.IdNumber == idNumber);
            if (cust == null || cust.Count() == 0)
                throw new NotRegistratedCustomerException("Customer is not in the register.");

            //TODO: Refactor
            var tmp = rentals.GetRentalsForTitle(movieTitle);
            var rented = tmp == null ? 0 : tmp.Count();
            
            if ((films.Count() - rented) <= 0)
                throw new NoMoreCopiesInStoreException("All copies are rented.");

            rentals.AddRental(movieTitle, idNumber);
        }

        public void ReturnMovie(string movieTitle, string idNumber)
        {
            if (string.IsNullOrEmpty(movieTitle) || string.IsNullOrWhiteSpace(movieTitle))
                throw new EmptyMovieTitleException("Missing title.");

            CheckIDFormat(idNumber);
            var rentalById = rentals.GetRentalsFor(idNumber);
            if (rentalById != null)
            {
                var rentalMovie = rentalById.Any(r => r.MovieTitle == movieTitle);
                //if (!rentals.GetRentalsFor(idNumber).Any(r => r.MovieTitle == movieTitle))
                if (!rentalMovie)
                {
                    throw new NotRegistratedRentalException($"{movieTitle} is not rented by {idNumber}.");
                }
                rentals.RemoveRental(movieTitle, idNumber);
            }
            else
            {
                throw new NotRegistratedRentalException($"{movieTitle} is not rented by {idNumber}.");
            }
        }

        private void CheckIDFormat(string id)
        {
            //@"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$"
            //@"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$
            Regex regex = new Regex(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$");
            if (!regex.Match(id).Success)
                throw new BadFormatException("ID: YYYY-MM-DD is expected.");
        }

        //Extra
        public Movie GetMovie(string title)
        {
            return movies.Where(m => m.Title == title).FirstOrDefault();

        }
    }
}
