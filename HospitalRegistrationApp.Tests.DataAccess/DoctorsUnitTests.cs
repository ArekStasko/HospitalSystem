using NUnit.Framework;
using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.DataAccess.models;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace HospitalRegistrationApp.Tests.DataAccess
{
    [TestFixture]
    public class DoctorsAccessTests
    {
        [SetUp]
        public void BeforeEveryTest()
        {
            
        }

        [Test]
        public void AddDoctor_should_AddOneDoctor()
        {
            var DoctorsDataProvider = new DoctorDataAccess();
            List<string> newDoctorData = new List<string>()
            {
                "12",
                "Pawel",
                "Jan",
                "Getrudy"
            };

            var doctor = new Doctor(newDoctorData);

            DoctorsDataProvider.AddDoctor(doctor);
            IEnumerable<Doctor> doctors = DoctorsDataProvider.GetDoctors();
            bool IsAdded = doctors.Any(item => item.DoctorID == doctor.DoctorID);
            Assert.IsTrue(IsAdded);
        }

    }
}