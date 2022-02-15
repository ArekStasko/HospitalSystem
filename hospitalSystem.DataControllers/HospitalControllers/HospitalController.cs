using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess.models;
using HospitalSystem.DataAccess;

namespace HospitalSystem.DataControllers.HospitalControllers
{
    public class HospitalController : IHospitalControllers
    {
        private int HospitalID { get; set; }
        private IView _view;
        private IHospitalDataAccess _hospitalProvider;

        public HospitalController(IView view)
        {
            _view = view;
            this.HospitalID = _view.GetID();
            _hospitalProvider = DataAccessFactory.GetNewHospitalDataAccessInstance();
        }

        public IEnumerable<IHospital> GetHospitals() => _hospitalProvider.GetHospitals();

        public IHospital GetHospital()
        {
            return _hospitalProvider.GetHospitals()
                .First(hospital => hospital.HospitalID == HospitalID);
        }

        public IEnumerable<IDoctor> GetHospitalDoctors()
        {
            var doctorControllers = ControllersFactory.NewDoctorControllersInstance(_view);
            return doctorControllers.GetDoctors()
                        .Where(doctor => doctor.HospitalID == HospitalID);
        }

        public IEnumerable<IVisit> GetAvailableVisits()
        {
            var visitsControllers = ControllersFactory.NewVisitControllersInstance(_view);
            return visitsControllers.GetVisits()
                        .Where(visit => visit.HospitalID == HospitalID);
        }

        private void SetHospital()
        {
            var hospitals = _hospitalProvider.GetHospitals();

            _view.PrintHospitals(hospitals);
            _view.PrintMessage("Please provide hospital ID from list :");
            HospitalID = _view.GetID();
        }
    }
}
