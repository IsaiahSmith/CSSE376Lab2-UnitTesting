using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here
        private readonly DateTime startDate = new DateTime(2015, 5, 20);
        private readonly DateTime endDate = new DateTime(2015, 5, 28);
        private readonly int someMiles = 5000;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, someMiles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDay()
        {
            var target = new Flight(new DateTime(2015, 5, 20), new DateTime(2015, 5, 21), 300);
            Assert.AreEqual(200 + 1 * 20, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOverAMonth()
        {
            var target = new Flight(new DateTime(2015, 5, 20), new DateTime(2015, 6, 23), 300);
            Assert.AreEqual(200 + 34 * 20, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForAYear()
        {
            var target = new Flight(new DateTime(2015, 5, 20), new DateTime(2016, 5, 20), 300000);
            Assert.AreEqual(200 + 366 * 20, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(new DateTime(2015, 5, 20), new DateTime(2012, 5, 20), 300000);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(new DateTime(2015, 5, 20), new DateTime(2016, 5, 20), -300);
        }
	}
}
