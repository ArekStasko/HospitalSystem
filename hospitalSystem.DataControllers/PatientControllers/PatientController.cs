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
            SetPatientHospital();
            var hospitalControllers = ControllersFactory.NewHospitalControllersInstance(_view, HospitalID);
            int selectedHospitalOption = _view.GetUserSelection();
            hospitalControllers.GetHospitalOptions(selectedHospitalOption);
        }

        private void SetPatientHospital()
        {
            var hospitalProvider = new HospitalsDataProvider();
            var hospitals = hospitalProvider.GetHospitals();

            _view.PrintHospitals(hospitals);
            _view.PrintMessage("Please provide hospital ID from list :");
            HospitalID = _view.GetID();
        }    

        public void ShowMyVisits()
        {
            var visitDataProvider = new VisitsDataAccess();
            var visits = visitDataProvider.GetVisits();

            _view.PrintMessage("Provide you ID :");
            var userID = _view.GetID();
            visits = visits.Where(visit => visit.UserID == userID);

            if (visits.Any())
            {
                _view.PrintVisits(visits);
            }
            else
            {
                throw new Exception($"There is no visit with {userID} user ID");
            }             

        }

        public void SignUpForVisit()
        {
            var visitDataProvider = new VisitsDataAccess();
            var visits = visitDataProvider.GetVisits();
            visits = visits.Where(visit => visit.Available && visit.HospitalID == HospitalID);

            try
            {
                Console.WriteLine("Available Visits :");
                _view.PrintVisits(visits);

                _view.PrintMessage("Select visit by ID :");
                int visitID = _view.GetID();

                while (!visits.Any(visit => visit.VisitID == visitID))
                {
                    _view.PrintMessage($"There is no visit with {visitID} ID");
                    visitID = _view.GetID();
                }

                var visitToForm = visits.First(visit => visit.VisitID == visitID);

                var doctorsDataProvider = new DoctorDataProvider();

                var doctors = doctorsDataProvider.GetDoctorsByHospitalID(HospitalID);
                _view.PrintDoctors(doctors);
                _view.PrintMessage("Provide doctor ID :");
                int doctorID = _view.GetID();

                visitToForm.DoctorID = doctorID;
                /*
                 For now there is no users object, i will make it
                 in the future when i will implement authentication
                 with authorization
                */
                visitToForm.UserID = visitToForm.VisitID;
                Console.WriteLine("Describe your problem :");
                visitToForm.Description = _view.GetData();
                visitToForm.Available = false;

                visitDataProvider.UpdateVisit(visitToForm);

                _view.PrintMessage($"Your ID : {visitToForm.UserID} Save it, you will need it when you want to read your visits ");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
