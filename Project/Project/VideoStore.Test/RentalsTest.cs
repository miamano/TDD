using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using VideoStore.Interfaces;
using VideoStore.BL;

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
        { }

        [Test]
        public void CanGetRentalsByID()
        { }

        [Test]
        public void CanRentMoreThanOneMovie()
        { }

        [Test]
        public void CanNotRentMoreThanThreeMovie()
        { }

        [Test]
        public void CanRentOnlyOneCopyPerCustomer()
        { }

        [Test]
        public void CanNotRentIfCustomerHasDueDate()
        { }
    }
}
