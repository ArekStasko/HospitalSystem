using NUnit.Framework;
using HospitalRegistrationApp.DataAccess;
using HospitalRegistrationApp.DataAccess.models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalRegistrationApp.Tests.DataAccess
{
    [TestFixture]
    public class DataAccessTests
    {
        [SetUp]
        public void BeforeEveryTest()
        {
            //TODO: add files clean up before every test 
        }

        [Test]
        public void AddHospital_should_AddOneHospital()
        {
            DataProvider dataProvider = new DataProvider();

            Hospital hospital = new Hospital()
            {
                HospitalID = 124,
                IsOnlinePrescriptions = "No",
                HospitalAdress = "Ul. makreli 312",
                HospitalOpeningTime = "9:00",
                HospitalClosingTime = "18:00"
            };

            dataProvider.AddHospital(hospital);
            IEnumerable<Hospital> hospitals = dataProvider.GetHospitals();
            bool IsAdded = hospitals.Any(item => item.HospitalID == hospital.HospitalID);
            Assert.IsTrue(IsAdded);
        }
    }
}