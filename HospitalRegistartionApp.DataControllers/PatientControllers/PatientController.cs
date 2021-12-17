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
            var visitDataProvider = new VisitsDataAccess();
            var showProvider = new ShowProvider();
            var visits = visitDataProvider.GetVisits();
            visits = visits.Where(visit => visit.Available && visit.HospitalID == HospitalID);

            try
            {
                Console.WriteLine("Available Visits :");
                showProvider.PrintVisits(visits);

                int visitID = GetID("Select visit by ID :");

                while (!visits.Any(visit => visit.VisitID == visitID))
                {
                    visitID = GetID($"There is no visit with {visitID} ID");
                }

                var visitToForm = visits.First(visit => visit.VisitID == visitID);

                var doctorsDataProvider = new DoctorDataProvider();

                var doctors = doctorsDataProvider.GetDoctorsByHospitalID(HospitalID);
                showProvider.PrintDoctors(doctors);
                int doctorID = GetID("Provide doctor ID :");

                visitToForm.DoctorID = doctorID;
                //For now this is only test 'ID'
                visitToForm.UserID = 123;
                Console.WriteLine("Describe your problem :");
                visitToForm.Description = Console.ReadLine();
                visitToForm.Available = false;

                visitDataProvider.UpdateVisit(visitToForm);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
