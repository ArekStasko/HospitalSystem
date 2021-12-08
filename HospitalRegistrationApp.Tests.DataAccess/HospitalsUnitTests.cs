using NUnit.Framework;
using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.DataAccess.models;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HospitalRegistrationApp.Tests.DataAccess
{
    [TestFixture]
    public class DataAccessTests
    {
        [SetUp]
        public void BeforeEveryTest()
        {
            var HospitalsDataProvider = new HospitalsDataProvider();

            var Hospitals = HospitalsDataProvider.GetHospitals().ToList();
            foreach(var hospital in Hospitals)
            {
                HospitalsDataProvider.RemoveHospital(hospital);
            }

        }

        [Test]
        public void AddHospital_should_AddOneHospital()
        {
            var HospitalsDataProvider = new HospitalsDataProvider();
            List<string> hospitalData = new List<string>() {
                "125",
                "No",
                "Ul. makreli 312",
                "9:00",
                "18:00"
            };

            Hospital hospital = new Hospital(hospitalData);

            HospitalsDataProvider.AddHospital(hospital);
            IEnumerable<Hospital> hospitals = HospitalsDataProvider.GetHospitals();
            bool IsAdded = hospitals.Any(item => item.HospitalID == hospital.HospitalID);
            Assert.IsTrue(IsAdded);
        }

        [Test]
        public void RemovingHospital_Should_RemoveOneHospital()
        {
            var HospitalsDataProvider = new HospitalsDataProvider();
            List<string> hospitalData = new List<string>() { 
                "904", 
                "No", 
                "Ul. makreli 312", 
                "9:00", 
                "18:00" 
            };

            Hospital hospital = new Hospital(hospitalData);

            HospitalsDataProvider.AddHospital(hospital);
            HospitalsDataProvider.RemoveHospital(hospital);

            var HospitalsFromFile = HospitalsDataProvider.GetHospitals().ToList();
            HospitalsFromFile.Should().NotContain(hospital);
        }
    }
}