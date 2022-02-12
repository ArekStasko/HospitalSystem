using HospitalSystem.DataAccess.DataAccessControllers;

namespace HospitalSystem.DataControllers.DoctorControllers
{
    public class DoctorController : IDoctorControllers
    {
        private IView _view;
        public DoctorController(IView view) => _view = view;

        private int DoctorHospitalID { get; set; }
        private int DoctorID { get; set; }
        public void DoctorAuthorization()
        {
            var dataProvider = new DoctorDataProvider();
            _view.PrintMessage("Please provide your ID :");
            int doctorID = _view.GetID();

            var doctors = dataProvider.GetDoctors();
            try { 
                var doctor = doctors.First(doc => doc.DoctorID == doctorID);
                DoctorHospitalID = doctor.HospitalID;
                DoctorID = doctor.DoctorID;
                Console.WriteLine($"You are logged in as {doctorID} doctor");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void GetDoctorHospital()
        {
            var dataProvider = new HospitalsDataProvider();
            var hospitals = dataProvider.GetHospitals();

            var doctorHospital = hospitals.First(hospital => hospital.HospitalID == DoctorHospitalID);

            _view.PrintMessage("Your hospital :");
            _view.PrintHospitals(doctorHospital);
        }

        public void GetDoctorVisits()
        {
            var visitsDataProvider = new VisitsDataAccess();
            var visits = visitsDataProvider.GetVisits();

            try
            {
                var visit = visits.First(visit => visit.DoctorID == DoctorID);
                _view.PrintVisit(visit);
            }
            catch (Exception)
            {
                throw new Exception("You don't have any visits");
            }
        }
    }
}
