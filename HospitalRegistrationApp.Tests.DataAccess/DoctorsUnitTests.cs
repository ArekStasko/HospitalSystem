using NUnit.Framework;
using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.DataAccess.models;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HospitalRegistrationApp.Tests.DataAccess
{
    [TestFixture]
    public class DoctorsUnitTests
    {
        [SetUp]
        public void BeforeEveryTest()
        {
            var DoctorsDataProvider = new DoctorDataProvider();

            var Doctors = DoctorsDataProvider.GetDoctors().ToList();

            foreach (var doctor in Doctors)
            {
                DoctorsDataProvider.RemoveDoctor(doctor);
            }
        }

        [Test]
        public void AddDoctor_Should_AddOneDoctor()
        {
            var DoctorsDataProvider = new DoctorDataProvider();
            List<string> newDoctorData = new List<string>()
            {
                "2137",
                "Pawel",
                "Jan",
                "7312"
            };

            var doctor = new Doctor(newDoctorData);

            DoctorsDataProvider.AddDoctor(doctor);
            var doctors = DoctorsDataProvider.GetDoctors();
            doctors.Should().Contain(doctor);
        }

        [Test]
        public void RemoveDoctor_Should_RemoveOneDoctor()
        {
            var DoctorsDataProvider = new DoctorDataProvider();
            List<string> newDoctorData = new List<string>()
            {
                "132",
                "Albert",
                "Nekko",
                "231"
            };

            var doctor = new Doctor(newDoctorData);

            DoctorsDataProvider.AddDoctor(doctor);
            DoctorsDataProvider.RemoveDoctor(doctor);

            var doctors = DoctorsDataProvider.GetDoctors();
            doctors.Should().NotContain(doctor);
        }

    }
}
