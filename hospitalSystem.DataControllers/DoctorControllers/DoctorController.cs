using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess;

namespace HospitalSystem.DataControllers.DoctorControllers
{
    public class DoctorController : IDoctorControllers
    {
        private IView _view;
        private IDoctorDataAccess _doctorProvider;
        private IHospitalDataAccess _hospitalProvider;
        private IVisitDataAccess _visitProvider;
        public DoctorController(IView view)
        {
            _view = view;
            _doctorProvider = DataAccessFactory.GetNewDoctorDataAccessInstance();
            _hospitalProvider = DataAccessFactory.GetNewHospitalDataAccessInstance();
            _visitProvider = DataAccessFactory.GetNewVisitDataAccessInstance();
        } 

        private int DoctorHospitalID { get; set; }
        private int DoctorID { get; set; }
        public void DoctorAuthorization()
        {
            _view.PrintMessage("Please provide your ID :");
            int doctorID = _view.GetID();

            var doctors = _doctorProvider.GetDoctors();
            try { 
                var doctor = doctors.First(doc => doc.DoctorID == doctorID);
                DoctorHospitalID = doctor.HospitalID;
                DoctorID = doctor.DoctorID;
                Console.WriteLine($"You are logged in as {doctorID} doctor");
            }
            catch(Exception)
            {
                _view.PrintMessage("Something went wrong");
                return;
            }
        }

        public void GetDoctorHospital()
        {
            var hospitals = _hospitalProvider.GetHospitals();
            var doctorHospital = hospitals.First(hospital => hospital.HospitalID == DoctorHospitalID);

            _view.PrintMessage("Your hospital :");
            _view.PrintHospitals(doctorHospital);
        }

        public void GetDoctorVisits()
        {
            var visits = _visitProvider.GetVisits();

            try
            {
                var visit = visits.First(visit => visit.DoctorID == DoctorID);
                _view.PrintVisit(visit);
            }
            catch (Exception)
            {
                _view.PrintMessage("You don't have any visits");
                return;
            }
        }
    }
}
