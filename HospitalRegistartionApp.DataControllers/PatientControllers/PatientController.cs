using System;
using System.Linq;
using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.DataAccess.models;
using HospitalRegistrationApp.Views;

namespace HospitalRegistrationApp.DataControllers.PatientControllers
{
    public class PatientController : DataGetController
    {
        protected int HospitalID { get; set; }

        public void SetPatientHospital()
        {
            var showProvider = new ShowProvider();
            var hospitalProvider = new HospitalsDataProvider();
            var hospitals = hospitalProvider.GetHospitals();

            showProvider.PrintHospitals(hospitals);
            var HospitalID = GetID("Please provide hospital ID from list :");

            if (hospitals.Any(hospital => hospital.HospitalID == HospitalID))
            {
                this.HospitalID = HospitalID;
                GetPatientOptions();
            }
            else Console.WriteLine($"There is no hospital with {HospitalID} ID ");
        }

        private void GetPatientOptions()
        {
            var optionsProvider = new OptionsProvider();

            optionsProvider.PrintPatientOptions();
            int selectedOption = GetUserSelection();

            switch (selectedOption)
            {
                case 1:
                    var hospitalControllers = new HospitalController(this.HospitalID);
                    optionsProvider.PrintHospitalOptions();
                    int selectedHospitalOption = GetUserSelection();
                    hospitalControllers.GetHospitalOptions(selectedHospitalOption);
                    break;
                case 2:
                    ShowMyVisits();
                    break;
                case 3:
                    SignUpForVisit();
                    break;
            }
        }

        private void ShowMyVisits()
        {
            Console.WriteLine("Visits");
        }

        private void SignUpForVisit()
        {
            Console.WriteLine("Sign up for visit");
        }
    }
}
