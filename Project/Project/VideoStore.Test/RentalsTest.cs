using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using VideoStore.Interfaces;
using VideoStore.BL;
using VideoStore.Exceptions;

namespace VideoStore.Test
{
    [TestFixture]
    public class RentalsTest
    {
        private IRentals sut;

        [SetUp]
        public void Setup()
        {
            sut = new Rentals();
        }

        [Test]
        public void CanAddRental()
        {
            sut.AddRental("Amelie", "1975-11-07");
            sut.AddRental("Vukk", "1975-11-07");

            var result = sut.GetRentalsFor("1975-11-07");

            Assert.That(result.Count == 2);
        }

        [Test]
        public void AllRentalHasThreeDaysDueDate()
        {
            sut.AddRental("Amelie", "1975-11-07");
            sut.AddRental("Vukk", "1975-11-07");

            var result = sut.GetRentalsFor("1975-11-07");

            foreach (var item in result)
            {
                Assert.That(item.DueDate == DateTime.Now.Date.AddDays(3));
            }
        }

        [Test]
        public void CanGetRentalsByID()
        {
            sut.AddRental("Amelie", "1975-11-07");
            var result = sut.GetRentalsFor("1975-11-07");

            Assert.That(result.Count == 1);
        }

        [Test]
        public void CanRentMoreThanOneMovie()
        {
            sut.AddRental("Amelie", "1975-11-07");
            sut.AddRental("Vukk", "1975-11-07");

            var result = sut.GetRentalsFor("1975-11-07");

            Assert.That(result.Count == 2);
        }

        [Test]
        public void CanNotRentMoreThanThreeMovie()
        {
            sut.AddRental("Amelie", "1975-11-07");
            sut.AddRental("Vukk", "1975-11-07");
            sut.AddRental("Forbidden Kingdom", "1975-11-07");

            Assert.Throws<NoMoreCopiesToRentException>(() => sut.AddRental("V for Vendetta", "1975-11-07"));
        }

        [Test]
        public void CanRentOnlyOneCopyPerCustomer()
        {
            sut.AddRental("Amelie", "1975-11-07");

            Assert.Throws<NoMoreCopiesToRentException>(() => sut.AddRental("Amelie", "1975-11-07"));
        }

        [Test]
        public void CanNotRentIfCustomerHasDueDate()
        {
            //Can not test that
        }
    }
}
