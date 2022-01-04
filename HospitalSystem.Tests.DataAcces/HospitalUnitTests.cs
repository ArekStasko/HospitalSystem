using NUnit.Framework;
using HospitalSystem.DataAccess.DataAccessControllers;
using HospitalSystem.DataAccess.models;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HospitalSystem.Tests.DataAccess
{
    [TestFixture]
    public class HospitalsAccessTests
    {
        [SetUp]
        public void BeforeEveryTest()
        {
            var HospitalsDataProvider = new HospitalsDataProvider();

            var Hospitals = HospitalsDataProvider.GetHospitals().ToList();
            foreach (var hospital in Hospitals)
            {
                HospitalsDataProvider.RemoveHospital(hospital);
            }

        }

        [Test]
        public void AddHospital_Should_AddOneHospital()
        {
            var HospitalsDataProvider = new HospitalsDataProvider();
            List<string> hospitalData = new List<string>() {
                "125",
                "Uniwersytecki",
                "Ul. makreli 312",
                "9:00",
                "18:00",
                "No"
            };

            Hospital hospital = new Hospital(hospitalData);

            HospitalsDataProvider.AddHospital(hospital);
            IEnumerable<Hospital> hospitals = HospitalsDataProvider.GetHospitals();
            hospitals.Should().Contain(hospital);
        }

        [Test]
        public void RemovingHospital_Should_RemoveOneHospital()
        {
            var HospitalsDataProvider = new HospitalsDataProvider();
            List<string> hospitalData = new List<string>() {
                "904",
                "Uniwersytecki",
                "Ul. makreli 312",
                "9:00",
                "18:00",
                "No"
            };

            Hospital hospital = new Hospital(hospitalData);

            HospitalsDataProvider.AddHospital(hospital);
            HospitalsDataProvider.RemoveHospital(hospital);

            var HospitalsFromFile = HospitalsDataProvider.GetHospitals();
            HospitalsFromFile.Should().NotContain(hospital);
        }
    }
}