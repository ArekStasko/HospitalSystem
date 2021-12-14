using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.Views;
using System;
using System.Linq;

namespace HospitalRegistrationApp.DataControllers.DoctorControllers
{
    public class DoctorController : DataGetController
    {
        private int DoctorHospitalID { get; set; }
        public void DoctorAuthorization()
        {
            var dataProvider = new DoctorDataProvider();
            int doctorID = GetID("Please provide your ID :");

            var doctors = dataProvider.GetDoctors();
            try { 
                var doctor = doctors.First(doc => doc.DoctorID == doctorID);
                DoctorHospitalID = doctor.HospitalID;
                Console.WriteLine($"You are logged in as {doctorID} doctor");
                GetDoctorOptions();
            }
            catch(Exception)
            {
                throw new Exception($"There is no doctor with {doctorID} ID");
            }
        }

        private void GetDoctorOptions()
        {
            var options = new OptionsProvider();
            options.PrintDoctorOptions();
            int userSelection = GetUserSelection();

            switch (userSelection)
            {
                case 1:
                    GetDoctorHospital();
                    break;
                case 2:
                    Console.WriteLine("You chose option number 2");
                    break;
                default:
                    Console.WriteLine("You chose wrong option number");
                    break;
            }
        }

        private void GetDoctorHospital()
        {
            var dataProvider = new HospitalsDataProvider();
            var hospitals = dataProvider.GetHospitals();

            var doctorHospital = hospitals.First(hospital => hospital.HospitalID == DoctorHospitalID);

            var showProvider = new ShowProvider();
            Console.WriteLine("Your hospital :");
            showProvider.PrintHospitals(doctorHospital);
        }
    }
}
