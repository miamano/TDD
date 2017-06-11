using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace TravelAgency.Test
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub tourScheduleStub;
        private BookingSystem sut;

        [SetUp]
        public void Setup()
        {
            tourScheduleStub = new TourScheduleStub();
            sut = new BookingSystem(tourScheduleStub);
        }

        [Test]
        public void CanCreateBooking()
        {
            var tour = new Tour("Nutella safari", new DateTime(2017, 06, 12), 2);
            tourScheduleStub.Tours = new List<Tour>(){ tour };

            var passengerOne = new Passenger("Krisztina", "Barta");
            var passengerTwo = new Passenger("Magnus", "Andersson");
            var passengerThree = new Passenger("Buci", "Duci");

            sut.CreateBooking("Nutella safari", new DateTime(2017, 06, 12), passengerOne);
            sut.CreateBooking("Nutella safari", new DateTime(2017, 06, 12), passengerTwo);

            List<Booking> bookings = sut.GetBookingFor(passengerOne);

            //Intressant!
            Assert.That(bookings.Count == 1);
            Assert.That(bookings[0].Tour.Equals(tour));
            Assert.That(bookings[0].Passenger.Equals(passengerOne));
            Assert.Throws<NotExistingTourException>(() => sut.CreateBooking("Wine safari", new DateTime(2017, 06, 12), passengerOne));
            Assert.Throws<FullbokedTourException>(() => sut.CreateBooking("Nutella safari", new DateTime(2017, 06, 12), passengerThree));

        }
    }
}
