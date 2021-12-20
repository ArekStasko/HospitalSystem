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

            while(selectedOption != 4)
            {
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
                        Console.Clear();
                        SignUpForVisit();
                        break;
                }
                optionsProvider.PrintPatientOptions();
                selectedOption = GetUserSelection();
            }
            
        }

        private void ShowMyVisits()
        {
            var visitDataProvider = new VisitsDataAccess();
            var visits = visitDataProvider.GetVisits();

            var userID = GetID("Provide you ID :");
            visits = visits.Where(visit => visit.UserID == userID);

            if (visits.Any())
            {
                var showProvider = new ShowProvider();
                showProvider.PrintVisits(visits);
            }
            else
            {
                throw new Exception($"There is no visit with {userID} user ID");
            }             

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
                /*
                 For now there is no users object, i will make it
                 in the future when i will implement authentication
                 with authorization
                */
                visitToForm.UserID = visitToForm.VisitID;
                Console.WriteLine("Describe your problem :");
                visitToForm.Description = Console.ReadLine();
                visitToForm.Available = false;

                visitDataProvider.UpdateVisit(visitToForm);

                Console.WriteLine($"Your ID : {visitToForm.UserID} Save it, you will need it when you want to read your visits ");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
