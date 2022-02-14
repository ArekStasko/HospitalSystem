using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess.models;
using HospitalSystem.DataAccess;

namespace HospitalSystem.DataControllers.AdminControllers
{
    public class AdminController : IAdminControllers
    {
        private IView _view;
        private IDoctorDataAccess _doctorProvider;
        private IHospitalDataAccess _hospitalProvider;
        private IVisitDataAccess _visitProvider;
        public AdminController(IView view)
        {
            _view = view;
            _doctorProvider = DataAccessFactory.GetNewDoctorDataAccessInstance();
            _hospitalProvider = DataAccessFactory.GetNewHospitalDataAccessInstance();
            _visitProvider = DataAccessFactory.GetNewVisitDataAccessInstance();
        }

        public void GetHospitalsAndDoctors()
        {
            var hospitals = _hospitalProvider.GetHospitals();
            var doctors = _doctorProvider.GetDoctors();

            
            foreach (var hospital in hospitals)
            {
                _view.PrintHospitals(hospital);
                var HospitalDoctors = doctors.Where(doctor => doctor.HospitalID == hospital.HospitalID);
                if(HospitalDoctors.Count() > 0)
                {
                    Console.WriteLine($"{hospital.HospitalName} hospital doctors :");
                    _view.PrintDoctors(HospitalDoctors);
                }
                else Console.WriteLine($"0 {hospital.HospitalName} hospital doctors");
            }

        }

        public void GetVisits() => _view.PrintVisits(_visitProvider.GetVisits());

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

        public void RemoveDoctor()
        {
            _view.PrintMessage("Please provide ID of doctor to remove");
            string providedData = _view.GetData();
            int DoctorID = Int32.Parse(providedData);
            try
            {
                IEnumerable<Doctor> doctors = _doctorProvider.GetDoctors();
                Doctor doctorToDelete = doctors.Single(item => item.DoctorID == DoctorID);
                _doctorProvider.RemoveDoctor(doctorToDelete);
                _view.PrintMessage("Successfully removed doctor");
            }
            catch (Exception)
            {
                _view.PrintMessage("Something went wrong");
            }
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
                while(prescAvailability == "Yes" || prescAvailability == "No")
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
                IEnumerable<Hospital> hospitals = _hospitalProvider.GetHospitals();
                Hospital hospitalToDelete = hospitals.Single(item => item.HospitalID == hospitalID);
                _hospitalProvider.RemoveHospital(hospitalToDelete);
                _view.PrintMessage("Successfully removed hospital");
            }
            catch (Exception)
            {
                _view.PrintMessage("Something went wrong");
            }
        }

        public void AddVisit()
        {
            List<string> visitData = new List<string>();
            var visits = _visitProvider.GetVisits();

            _view.PrintMessage("Provide Visit ID :");
            int visitID = _view.GetID();

            while(visits.Any(visit=>visit.VisitID == visitID))
            {
                _view.PrintMessage($"There is already visit with {visitID} ID");
                visitID = _view.GetID();
            }
          
            visitData.Add(visitID.ToString());
            _view.PrintMessage("Provide Hospital ID :");
            visitData.Add(_view.GetID().ToString());
            Console.WriteLine("Provide time of visit");
            visitData.Add(_view.GetData());

            Visit visit = new Visit(visitData);
            visit.Available = true;
            _visitProvider.AddVisit(visit);
        }

        public void RemoveVisit()
        {
            _view.PrintMessage("Please provide visit ID to remove");
            int visitID = _view.GetID();

            var visits = _visitProvider.GetVisits();
            try
            {
                var VisitToRemove = visits.First(visit => visit.VisitID == visitID);
                _visitProvider.RemoveVisit(VisitToRemove);
            }
            catch (Exception)
            {
                _view.PrintMessage($"There is no visit with {visitID} to remove");
            }
        }

    }
}
