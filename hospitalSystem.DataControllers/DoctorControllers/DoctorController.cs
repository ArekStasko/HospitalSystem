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

        public void AddDoctor()
        {
            List<string> newDoctorData = new List<string>();

            string[] dataToCollect = new string[]
            {
            "Doctor firstName",
            "Doctor lastName",
            };

            try
            {
                _view.PrintMessage("Provide doctor ID");
                int newDoctorID = _view.GetID();

                var doctors = _doctorProvider.GetDoctors();
                while (doctors.Any(doctor => doctor.DoctorID == newDoctorID))
                {
                    _view.PrintMessage($"You already have doctor with {newDoctorID} ID");
                    newDoctorID = _view.GetID();
                }

                newDoctorData.Add(newDoctorID.ToString());

                foreach (var dataQuery in dataToCollect)
                {
                    _view.PrintMessage($"Please provide {dataQuery} :");
                    newDoctorData.Add(_view.GetData());
                }
                newDoctorData.Add(_view.GetID().ToString());

                var newDoctor = new Doctor(newDoctorData);
                _doctorProvider.AddDoctor(newDoctor);
            }
            catch (Exception)
            {
                _view.PrintMessage("Something went wrong");
                return;
            }
        }

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

        public void RemoveDoctor()
        {
            _view.PrintMessage("Please provide ID of doctor to remove");
            string providedData = _view.GetData();
            int DoctorID = Int32.Parse(providedData);
            try
            {
                IEnumerable<IDoctor> doctors = _doctorProvider.GetDoctors();
                IDoctor doctorToDelete = doctors.Single(item => item.DoctorID == DoctorID);
                _doctorProvider.RemoveDoctor(doctorToDelete);
                _view.PrintMessage("Successfully removed doctor");
            }
            catch (Exception)
            {
                _view.PrintMessage("Something went wrong");
            }
        }
    }
}
