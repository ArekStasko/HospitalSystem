using HospitalSystem.DataAccess.DataAccessControllers;
using HospitalSystem.DataControllers.HospitalControllers;

namespace HospitalSystem.DataControllers.PatientControllers
{
    public class PatientController : IPatientControllers
    {
        private IView _view;
        public PatientController(IView view) => _view = view;

        protected int HospitalID { get; set; }

        public void HospitalOptions()
        {
            var hospitalControllers = ControllersFactory.NewHospitalControllersInstance(HospitalID);
            PrintHospitalOptions();
            int selectedHospitalOption = _view.GetUserSelection();
            hospitalControllers.GetHospitalOptions(selectedHospitalOption);
        }

        public void SetPatientHospital()
        {
            var hospitalProvider = new HospitalsDataProvider();
            var hospitals = hospitalProvider.GetHospitals();

            _view.PrintHospitals(hospitals);
            Console.WriteLine("Please provide hospital ID from list :");
            var HospitalID = _view.GetID();

            if (hospitals.Any(hospital => hospital.HospitalID == HospitalID))
            {
                this.HospitalID = HospitalID;
                GetPatientOptions();
            }
            else Console.WriteLine($"There is no hospital with {HospitalID} ID ");
        }    

        public void ShowMyVisits()
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

        public void SignUpForVisit()
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
