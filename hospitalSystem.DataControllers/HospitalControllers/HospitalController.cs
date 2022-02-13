using HospitalSystem.DataAccess.DataAccessControllers;

namespace HospitalSystem.DataControllers.HospitalControllers
{
    public class HospitalController : IHospitalControllers
    {
        private new int HospitalID { get; set; }
        private IView _view;

        public HospitalController(IView view, int HospitalID)
        {
            this.HospitalID = HospitalID;
            _view = view;
        }

        public void GetHospitalOptions(int selectedOption)
        {

            switch (selectedOption)
            {
                case 1:

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

        public void GetHospitalInfo()
        {
            var hospitalProvider = new HospitalsDataProvider();
            var hospital = hospitalProvider.GetHospitals()
                .First(hospital => hospital.HospitalID == HospitalID);

            _view.PrintHospitals(hospital);
        }

        public void GetHospitalDoctors()
        {
            var doctorsProvider = new DoctorDataProvider();
            var doctors = doctorsProvider.GetDoctors()
                        .Where(doctor => doctor.HospitalID == HospitalID);
            _view.PrintDoctors(doctors);
        }

        public void ShowAvailableVisits()
        {
            var visitsProvider = new VisitsDataAccess();

            var visits = visitsProvider.GetVisits();
            visits = visits.Where(visit => visit.HospitalID == HospitalID);

            if (visits.Any())
            {
                _view.PrintVisits(visits);
            }
            else
            {
                throw new Exception("This hospital doesn't have available visits");
            }
        }
    }
}
