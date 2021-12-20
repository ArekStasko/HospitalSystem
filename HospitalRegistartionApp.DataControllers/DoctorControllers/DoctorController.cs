using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.Views;
using System;
using System.Linq;

namespace HospitalRegistrationApp.DataControllers.DoctorControllers
{
    public class DoctorController : DataGetController
    {
        private int DoctorHospitalID { get; set; }
        private int DoctorID { get; set; }
        public void DoctorAuthorization()
        {
            var dataProvider = new DoctorDataProvider();
            int doctorID = GetID("Please provide your ID :");

            var doctors = dataProvider.GetDoctors();
            try { 
                var doctor = doctors.First(doc => doc.DoctorID == doctorID);
                DoctorHospitalID = doctor.HospitalID;
                DoctorID = doctor.DoctorID;
                Console.WriteLine($"You are logged in as {doctorID} doctor");
                GetDoctorOptions();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void GetDoctorOptions()
        {
            var options = new OptionsProvider();
            options.PrintDoctorOptions();
            int userSelection = GetUserSelection();

            while (userSelection != 3)
            {
                switch (userSelection)
                {
                    case 1:
                        GetDoctorHospital();
                        break;
                    case 2:
                        GetDoctorVisits();
                        break;
                    default:
                        Console.WriteLine("You chose wrong option number");
                        break;
                }
                options.PrintDoctorOptions();
                userSelection = GetUserSelection();
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

        private void GetDoctorVisits()
        {
            var visitsDataProvider = new VisitsDataAccess();
            var visits = visitsDataProvider.GetVisits();

            try
            {
                var visit = visits.First(visit => visit.DoctorID == DoctorID);
                var showProvider = new ShowProvider();
                showProvider.PrintVisit(visit);
            }
            catch (Exception)
            {
                throw new Exception("You don't have any visits");
            }
        }
    }
}
