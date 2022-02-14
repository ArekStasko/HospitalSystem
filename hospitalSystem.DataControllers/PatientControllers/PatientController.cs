using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess;

namespace HospitalSystem.DataControllers.PatientControllers
{
    public class PatientController : IPatientControllers
    {
        private IView _view;
        private int HospitalID { get; set; }
        private IHospitalDataAccess _hospitalProvider;
        private IVisitDataAccess _visitProvider;
        public PatientController(IView view)
        {
            _view = view;
            _hospitalProvider = DataAccessFactory.GetNewHospitalDataAccessInstance();
            _visitProvider = DataAccessFactory.GetNewVisitDataAccessInstance();
        }


        public void HospitalOptions()
        {
            SetPatientHospital();
            var hospitalControllers = ControllersFactory.NewHospitalControllersInstance(_view, HospitalID);
            int selectedHospitalOption = _view.GetUserSelection();
            hospitalControllers.GetHospitalOptions(selectedHospitalOption);
        }

        private void SetPatientHospital()
        {
            var hospitals = _hospitalProvider.GetHospitals();

            _view.PrintHospitals(hospitals);
            _view.PrintMessage("Please provide hospital ID from list :");
            HospitalID = _view.GetID();
        }    

        public void ShowMyVisits()
        {
            var visits = _visitProvider.GetVisits();

            _view.PrintMessage("Provide you ID :");
            var userID = _view.GetID();
            visits = visits.Where(visit => visit.UserID == userID);

            if(!visits.Any())
            {
                _view.PrintMessage($"There is no visit with {userID} user ID");
            }

            _view.PrintVisits(visits);
        }

        public void SignUpForVisit()
        {
            var visitDataProvider = new VisitsDataAccess();
            var visits = visitDataProvider.GetVisits();
            visits = visits.Where(visit => visit.Available && visit.HospitalID == HospitalID);

            try
            {
                _view.PrintMessage("Available Visits :");
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
                _view.PrintMessage("Describe your problem :");
                visitToForm.Description = _view.GetData();
                visitToForm.Available = false;

                visitDataProvider.UpdateVisit(visitToForm);

                _view.PrintMessage($"Your ID : {visitToForm.UserID} Save it, you will need it when you want to read your visits ");
            }
            catch (Exception)
            {
                _view.PrintMessage("Something went wrong");
                return;
            }
        }
    }
}
