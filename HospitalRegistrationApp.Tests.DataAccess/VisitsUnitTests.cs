using NUnit.Framework;
using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.DataAccess.models;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HospitalRegistrationApp.Tests.DataAccess
{
    [TestFixture]
    class VisitsUnitTests
    {
        [SetUp]
        public void BeforeEveryTest()
        {
            var VisitsDataProvider = new VisitsDataAccess();

            var visits = VisitsDataProvider.GetVisits().ToList();

            foreach (var visit in visits)
            {
                VisitsDataProvider.RemoveVisit(visit);
            }
        }

        [Test]
        public void AddMainVisit_Should_AddOneMainVisit()
        {
            var VisitsDataProvider = new VisitsDataAccess();

            List<string> newVisitData = new List<string>()
            {
                "123",
                "321",
                "Yes"
            };

            var visit = new Visit(newVisitData);

            VisitsDataProvider.AddVisit(visit);
            var visits = VisitsDataProvider.GetVisits();
            visits.Should().Contain(visit);
        }

        [Test]
        public void AddFullVisit_Should_AddOneFullVisit()
        {
            var VisitsDataProvider = new VisitsDataAccess();

            List<string> newVisitData = new List<string>()
            {
                "123",
                "321",
                "Yes"
            };

            var visit = new Visit(newVisitData);

            visit.DoctorID = 456;
            visit.UserID = 654;
            visit.Description = "Cool visit"; 

            VisitsDataProvider.AddVisit(visit);
            var visits = VisitsDataProvider.GetVisits();
            visits.Should().Contain(visit);
        }

        [Test]
        public void RemoveMainVisit_Should_RemoveOneMainVisit()
        {
            var VisitsDataProvider = new VisitsDataAccess();

            List<string> newVisitData = new List<string>()
            {
                "123",
                "321",
                "Yes"
            };

            var visit = new Visit(newVisitData);

            VisitsDataProvider.AddVisit(visit);
            VisitsDataProvider.RemoveVisit(visit);

            var visits = VisitsDataProvider.GetVisits();
            visits.Should().NotContain(visit);
        }

        [Test]
        public void RemoveFullVisit_Should_RemoveOneFullVisit()
        {
            var VisitsDataProvider = new VisitsDataAccess();

            List<string> newVisitData = new List<string>()
            {
                "123",
                "321",
                "Yes"
            };

            var visit = new Visit(newVisitData);

            visit.DoctorID = 456;
            visit.UserID = 654;
            visit.Description = "Cool visit";

            VisitsDataProvider.AddVisit(visit);
            VisitsDataProvider.RemoveVisit(visit);

            var visits = VisitsDataProvider.GetVisits();
            visits.Should().NotContain(visit);
        }

    }
}
