using NUnit.Framework;
using HospitalSystem.DataAccess.DataAccessControllers;
using HospitalSystem.DataAccess.models;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HospitalSystem.Tests.DataAccess
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
                "18:30"
            };

            var visit = new Visit(newVisitData);
            visit.Available = true;

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
                "18:30"
            };

            var visit = new Visit(newVisitData);

            visit.Available = true;
            visit.DoctorID = 456;
            visit.UserID = 654;
            visit.Description = "Cool visit";

            VisitsDataProvider.AddVisit(visit);
            VisitsDataProvider.RemoveVisit(visit);

            var visits = VisitsDataProvider.GetVisits();
            visits.Should().NotContain(visit);
        }

        [Test]
        public void UpdateOneVisit_should_RemoveAndAddNewVisit()
        {
            var VisitsDataProvider = new VisitsDataAccess();

            List<string> newVisitData = new List<string>()
            {
                "123",
                "321",
                "18:30"
            };

            var visit = new Visit(newVisitData);
            visit.Available = true;

            VisitsDataProvider.AddVisit(visit);
            var visits = VisitsDataProvider.GetVisits();

            visits = visits.Where(visit => visit.Available && visit.HospitalID == 321);
            var visitToUpdate = visits.First(visit => visit.VisitID == 123);

            visitToUpdate.Available = false;
            visitToUpdate.DoctorID = 456;
            visitToUpdate.UserID = 654;
            visitToUpdate.Description = "Cool visit";

            VisitsDataProvider.UpdateVisit(visitToUpdate);
            visits = VisitsDataProvider.GetVisits();
            visits.Should().Contain(visitToUpdate)
                .Which.Available.Should().BeFalse();

        }

    }
}