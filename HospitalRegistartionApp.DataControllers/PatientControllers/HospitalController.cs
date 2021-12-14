using System;
using System.Linq;
using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.DataAccess.models;
using HospitalRegistrationApp.Views;

namespace HospitalRegistrationApp.DataControllers.PatientControllers
{
    public class HospitalController : PatientController
    {
        private new int HospitalID { get; set; }

        public HospitalController(int HospitalID)
        {
            this.HospitalID = HospitalID;
        }

        public void GetHospitalOptions(int selectedOption)
        {

            switch (selectedOption)
            {
                case 1:
                    base.SetPatientHospital();
                    break;
                case 2:
                    GetHospitalInfo();
                    break;
                case 3:
                    GetHospitalDoctors();
                    break;
                case 4:
                    ShowAvailableVisits();
                    break;
            }
        }

        private void GetHospitalInfo()
        {
            var hospitalProvider = new HospitalsDataProvider();
            var hospital = hospitalProvider.GetHospitals()
                .First(hospital => hospital.HospitalID == HospitalID);

            var showProvider = new ShowProvider();
            showProvider.PrintHospitals(hospital);
        }

        private void GetHospitalDoctors()
        {
            var showProvider = new ShowProvider();
            var doctorsProvider = new DoctorDataProvider();
            var doctors = doctorsProvider.GetDoctors()
                        .Where(doctor => doctor.HospitalID == HospitalID);
            showProvider.PrintDoctors(doctors);
        }

        private void ShowAvailableVisits()
        {
            Console.WriteLine("Available visits");
        }
    }
}
