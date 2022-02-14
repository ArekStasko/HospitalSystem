using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess;

namespace HospitalSystem.DataControllers.HospitalControllers
{
    public class HospitalController : IHospitalControllers
    {
        private int HospitalID { get; set; }
        private IView _view;
        private IDoctorDataAccess _doctorProvider;
        private IHospitalDataAccess _hospitalProvider;
        private IVisitDataAccess _visitProvider;

        public HospitalController(IView view, int HospitalID)
        {
            this.HospitalID = HospitalID;
            _view = view;
            _doctorProvider = DataAccessFactory.GetNewDoctorDataAccessInstance();
            _hospitalProvider = DataAccessFactory.GetNewHospitalDataAccessInstance();
            _visitProvider = DataAccessFactory.GetNewVisitDataAccessInstance();
        }

        public void GetHospitalOptions(int selectedOption)
        {

            switch (selectedOption)
            {
                case 1:
                    //Not implemented yet
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
            var hospital = _hospitalProvider.GetHospitals()
                .First(hospital => hospital.HospitalID == HospitalID);

            _view.PrintHospitals(hospital);
        }

        public void GetHospitalDoctors()
        {
            var doctors = _doctorProvider.GetDoctors()
                        .Where(doctor => doctor.HospitalID == HospitalID);
            _view.PrintDoctors(doctors);
        }

        public void ShowAvailableVisits()
        {
            var visits = _visitProvider.GetVisits();
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
