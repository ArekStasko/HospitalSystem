using HospitalSystem.DataAccess.DataAccessControllers;
using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers.AdminControllers
{
    public class AdminController : IAdminControllers
    {
        private IView _view;

        public AdminController(IView view) => _view = view;
        

        public void GetHospitalsAndDoctors()
        {
            var doctorDataProvider = new DoctorDataProvider();
            var hospitalDataProvider = new HospitalsDataProvider();

            var hospitals = hospitalDataProvider.GetHospitals();
            var doctors = doctorDataProvider.GetDoctors();

            
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

        public void GetVisits()
        {
            var visitProvider = new VisitsDataAccess();
            var visits = visitProvider.GetVisits();

            _view.PrintVisits(visits);
        }

        public void AddDoctor()
        {
            var dataProvider = new DoctorDataProvider();
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

                var doctors = dataProvider.GetDoctors();
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
                dataProvider.AddDoctor(newDoctor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveDoctor()
        {
            var dataProvider = new DoctorDataProvider();

            _view.PrintMessage("Please provide ID of doctor to remove");
            string providedData = _view.GetData();
            int DoctorID = Int32.Parse(providedData);
            try
            {
                IEnumerable<Doctor> doctors = dataProvider.GetDoctors();
                Doctor doctorToDelete = doctors.Single(item => item.DoctorID == DoctorID);
                dataProvider.RemoveDoctor(doctorToDelete);
                _view.PrintMessage("Successfully removed doctor");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddHospital()
        {
            var dataProvider = new HospitalsDataProvider();

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

                dataProvider.AddHospital(hospital);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void RemoveHospital()
        {
            var dataProvider = new HospitalsDataProvider();

            _view.PrintMessage("Please provide ID of hospital to remove");
            string providedData = _view.GetData();
            int hospitalID = Int32.Parse(providedData);
            try
            {
                IEnumerable<Hospital> hospitals = dataProvider.GetHospitals();
                Hospital hospitalToDelete = hospitals.Single(item => item.HospitalID == hospitalID);
                dataProvider.RemoveHospital(hospitalToDelete);
                _view.PrintMessage("Successfully removed hospital");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddVisit()
        {
            var visitProvider = new VisitsDataAccess();
            List<string> visitData = new List<string>();
            var visits = visitProvider.GetVisits();

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
            visitProvider.AddVisit(visit);
        }

        public void RemoveVisit()
        {
            var visitProvider = new VisitsDataAccess();
            _view.PrintMessage("Please provide visit ID to remove");
            int visitID = _view.GetID();

            var visits = visitProvider.GetVisits();
            try
            {
                var VisitToRemove = visits.First(visit => visit.VisitID == visitID);
                visitProvider.RemoveVisit(VisitToRemove);
            }
            catch (Exception)
            {
                _view.PrintMessage($"There is no visit with {visitID} to remove");
            }
        }

    }
}
