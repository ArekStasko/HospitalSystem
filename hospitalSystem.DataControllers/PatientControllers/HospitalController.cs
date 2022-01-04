using HospitalSystem.DataAccess.DataAccessControllers;
using HospitalSystem.Views;

namespace HospitalSystem.DataControllers.PatientControllers
{
    public class HospitalController : PatientController
    {
        private new int HospitalID { get; set; }

        public HospitalController(int HospitalID)
        {
            this.HospitalID = HospitalID;
        }

        public void GetHospitalOptions(int selectedOption)
        {

            switch (selectedOption)
            {
                case 1:
                    base.SetPatientHospital();
                    break;
                case 2:
                    GetHospitalInfo();
                    break;
                case 3:
                    GetHospitalDoctors();
                    break;
                case 4:
                    ShowAvailableVisits();
                    break;
            }
        }

        private void GetHospitalInfo()
        {
            var hospitalProvider = new HospitalsDataProvider();
            var hospital = hospitalProvider.GetHospitals()
                .First(hospital => hospital.HospitalID == HospitalID);

            var showProvider = new ShowProvider();
            showProvider.PrintHospitals(hospital);
        }

        private void GetHospitalDoctors()
        {
            var showProvider = new ShowProvider();
            var doctorsProvider = new DoctorDataProvider();
            var doctors = doctorsProvider.GetDoctors()
                        .Where(doctor => doctor.HospitalID == HospitalID);
            showProvider.PrintDoctors(doctors);
        }

        private void ShowAvailableVisits()
        {
            var visitsProvider = new VisitsDataAccess();

            var visits = visitsProvider.GetVisits();
            visits = visits.Where(visit => visit.HospitalID == base.HospitalID);

            if (visits.Any())
            {
                var showProvider = new ShowProvider();
                showProvider.PrintVisits(visits);
            }
            else
            {
                throw new Exception("This hospital doesn't have available visits");
            }
        }
    }
}
