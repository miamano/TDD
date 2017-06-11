using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class BookingSystem
    {
        private ITourSchedule tourSchedule;
        private List<Booking> bookings;

        public BookingSystem(ITourSchedule tourSchedule)
        {
            this.tourSchedule = tourSchedule;
            bookings = new List<Booking>();
        }

        public void CreateBooking(string nameOfTour, DateTime when, Passenger passenger)
        {
            List<Tour> tours = tourSchedule.GetToursFor(when);
            Tour tour = tours.Where(t => t.Name == nameOfTour).FirstOrDefault();
            

            if (tour == null)
                throw new NotExistingTourException();

            int bookedSeats = bookings.Where(b => b.Tour == tour).Count(); //TODO: Equals?
            if (bookedSeats < tour.Seat)
            {
                bookings.Add(new Booking(passenger, tour));
            }
            else
            {
                throw new FullbokedTourException();
            }
        }

        public List<Booking> GetBookingFor(Passenger passenger)
        {
            return bookings.Where(b => b.Passenger == passenger).ToList();  //TODO: Equals?
        }

    }
}
