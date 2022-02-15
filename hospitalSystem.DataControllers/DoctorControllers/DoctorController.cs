using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess;
using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers.DoctorControllers
{
    public class DoctorController : IDoctorControllers
    {
        private int DoctorHospitalID { get; set; }
        private int DoctorID { get; set; }

        private IView _view;
        private IDoctorDataAccess _doctorProvider;

        public DoctorController(IView view)
        {
            _view = view;
            _doctorProvider = DataAccessFactory.GetNewDoctorDataAccessInstance();
        } 

        public IEnumerable<IDoctor> GetDoctors() => _doctorProvider.GetDoctors();
        

        public void DoctorAuthorization()
        {
            _view.PrintMessage("Please provide your ID :");
            int doctorID = _view.GetID();

            var doctors = _doctorProvider.GetDoctors();
            try { 
                var doctor = doctors.First(doc => doc.DoctorID == doctorID);
                DoctorHospitalID = doctor.HospitalID;
                DoctorID = doctor.DoctorID;
                _view.PrintMessage($"You are logged in as {doctorID} doctor");
            }
            catch(Exception)
            {
                _view.PrintMessage("Something went wrong");
                return;
            }
        }

        public IHospital GetDoctorHospital()
        {
            var hospitalController = ControllersFactory.NewHospitalControllersInstance(_view);
            var hospitals = hospitalController.GetHospitals();

            return hospitals.First(hospital => hospital.HospitalID == DoctorHospitalID);
        }

        public IEnumerable<IVisit> GetDoctorVisits()
        {
            var visitController = ControllersFactory.NewVisitControllersInstance(_view);
            var visits = visitController.GetVisits();

            return visits.Where(visit => visit.DoctorID == DoctorID);
        }
    }
}
