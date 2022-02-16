using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess.models;
using HospitalSystem.DataAccess;

namespace HospitalSystem.DataControllers.AdminControllers
{
    public class VisitControllers : IVisitControllers
    {
        private IView _view;
        private IDoctorDataAccess _doctorProvider;
        private IHospitalDataAccess _hospitalProvider;
        private IVisitDataAccess _visitProvider;
        public VisitControllers(IView view)
        {
            _view = view;
            _doctorProvider = DataAccessFactory.GetNewDoctorDataAccessInstance();
            _hospitalProvider = DataAccessFactory.GetNewHospitalDataAccessInstance();
            _visitProvider = DataAccessFactory.GetNewVisitDataAccessInstance();
        }

        public IEnumerable<IVisit> GetVisits() => _visitProvider.GetVisits();        

        public void AddVisit()
        {
            List<string> visitData = new List<string>();
            var visits = _visitProvider.GetVisits();

            _view.PrintMessage("Provide Visit ID :");
            int visitID = _view.GetID();

            while(visits.Any(visit=>visit.VisitID == visitID))
            {
                _view.PrintMessage($"There is already visit with {visitID} ID");
                visitID = _view.GetID();
            }
          
            visitData.Add(visitID.ToString());
            _view.PrintMessage("Provide Hospital ID :");
            visitData.Add(_view.GetID().ToString());
            Console.WriteLine("Provide time of visit");
            visitData.Add(_view.GetData());

            Visit visit = new Visit(visitData);
            visit.Available = true;
            _visitProvider.AddVisit(visit);
        }

        public void RemoveVisit()
        {
            _view.PrintMessage("Please provide visit ID to remove");
            int visitID = _view.GetID();

            var visits = _visitProvider.GetVisits();
            try
            {
                var VisitToRemove = visits.First(visit => visit.VisitID == visitID);
                _visitProvider.RemoveVisit(VisitToRemove);
            }
            catch (Exception)
            {
                _view.PrintMessage($"There is no visit with {visitID} to remove");
            }
        }

        public void GetMyVisits()
        {
            var visits = _visitProvider.GetVisits();

            _view.PrintMessage("Provide you ID :");
            var userID = _view.GetID();
            visits = visits.Where(visit => visit.UserID == userID);

            if (!visits.Any())
            {
                _view.PrintMessage($"There is no visit with {userID} user ID");
            }

            _view.PrintVisits(visits);
        }


        public void SignUpForVisit()
        {
            var visitDataProvider = new VisitsDataAccess();
            var visits = visitDataProvider.GetVisits();
            _view.PrintMessage("Provide hospital ID");
            int hospitalID = _view.GetID();
            visits = visits.Where(visit => visit.Available && visit.HospitalID == hospitalID);

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

                var doctors = doctorsDataProvider.GetDoctorsByHospitalID(hospitalID);
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
