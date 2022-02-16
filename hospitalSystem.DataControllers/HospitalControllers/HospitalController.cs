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
            SetHospital();
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

        public void AddHospital()
        {
            List<string> newHospitalData = new List<string>() { };
            string[] dataToCollect = new string[]
            {
                "Hospital Name",
                "Hospital Adress",
                "Hospital Opening Time",
                "Hospital Closing time",
            };

            try
            {
                newHospitalData.Add(_view.GetID().ToString());

                foreach (var dataQuery in dataToCollect)
                {
                    _view.PrintMessage($"Please provide {dataQuery} :");
                    newHospitalData.Add(_view.GetData());
                }

                _view.PrintMessage("Online Prescriptions availability : Yes/No");
                string prescAvailability = _view.GetData();
                while (prescAvailability == "Yes" || prescAvailability == "No")
                {
                    _view.PrintMessage("Please provide 'Yes' or 'No' :");
                    prescAvailability = _view.GetData();
                }

                var hospital = new Hospital(newHospitalData);

                _hospitalProvider.AddHospital(hospital);
            }
            catch (Exception)
            {
                _view.PrintMessage("Something Went Wrong");
            }

        }

        public void RemoveHospital()
        {
            _view.PrintMessage("Please provide ID of hospital to remove");
            string providedData = _view.GetData();
            int hospitalID = Int32.Parse(providedData);
            try
            {
                IEnumerable<IHospital> hospitals = _hospitalProvider.GetHospitals();
                var hospitalToDelete = hospitals.Single(item => item.HospitalID == hospitalID);
                _hospitalProvider.RemoveHospital(hospitalToDelete);
                _view.PrintMessage("Successfully removed hospital");
            }
            catch (Exception)
            {
                _view.PrintMessage("Something went wrong");
            }
        }

        public void SetHospital()
        {
            var hospitals = _hospitalProvider.GetHospitals();

            _view.PrintHospitals(hospitals);
            _view.PrintMessage("Please provide hospital ID from list :");
            HospitalID = _view.GetID();
        }
    }
}
