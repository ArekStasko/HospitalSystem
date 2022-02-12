using HospitalSystem.DataAccess.DataAccessControllers;
using HospitalSystem.Views;

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
            int doctorID = GetID("Please provide your ID :");

            var doctors = dataProvider.GetDoctors();
            try { 
                var doctor = doctors.First(doc => doc.DoctorID == doctorID);
                DoctorHospitalID = doctor.HospitalID;
                DoctorID = doctor.DoctorID;
                Console.WriteLine($"You are logged in as {doctorID} doctor");
                GetDoctorOptions();
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

            var showProvider = new ShowProvider();
            Console.WriteLine("Your hospital :");
            showProvider.PrintHospitals(doctorHospital);
        }

        public void GetDoctorVisits()
        {
            var visitsDataProvider = new VisitsDataAccess();
            var visits = visitsDataProvider.GetVisits();

            try
            {
                var visit = visits.First(visit => visit.DoctorID == DoctorID);
                var showProvider = new ShowProvider();
                showProvider.PrintVisit(visit);
            }
            catch (Exception)
            {
                throw new Exception("You don't have any visits");
            }
        }
    }
}
