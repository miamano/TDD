using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TravelAgency.Test
{
    [TestFixture]
    public class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }

        [Test]
        public void CanCreateNewTour()
        {
            sut.CreateTour("Nutella safari", new DateTime(2017, 06, 12), 10);

            var tours = sut.GetToursFor(new DateTime(2017, 06, 12));

            Assert.AreEqual(1, tours.Count);
            Assert.AreSame("Nutella safari", tours[0].Name);
        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            sut.CreateTour("Nutella safari", new DateTime(2017, 06, 12, 10, 15, 0), 10);

            var tours = sut.GetToursFor(new DateTime(2017, 06, 12));

            Assert.AreEqual("Nutella safari", tours[0].Name);
            Assert.AreEqual(1, tours.Count);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour("Polkagris safari", new DateTime(2017, 06, 12), 10);
            sut.CreateTour("Nutella safari", new DateTime(2017, 06, 13), 10);
            sut.CreateTour("Oreo safari", new DateTime(2017, 06, 12), 10);

            var tours12 = sut.GetToursFor(new DateTime(2017, 06, 12));
            var tours13 = sut.GetToursFor(new DateTime(2017, 06, 13));

            Assert.AreEqual(2, tours12.Count);
            Assert.AreNotSame(tours12[0].Name, tours12[1].Name);
            Assert.AreEqual(1, tours13.Count);
        }

        [Test]
        public void MoreThanThreeToursSchedulingAtTheSameDate()
        {
            sut.CreateTour("Polkagris safari", new DateTime(2017, 06, 12), 10);
            sut.CreateTour("Nutella safari", new DateTime(2017, 06, 12), 10);
            sut.CreateTour("Oreo safari", new DateTime(2017, 06, 12), 10);

            Assert.Throws<TourAllocationException>(() => sut.CreateTour("Wine safari", new DateTime(2017, 06, 12), 10));
        }
    }
}
