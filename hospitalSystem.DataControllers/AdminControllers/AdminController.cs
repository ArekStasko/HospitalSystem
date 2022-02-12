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
                showProvider.PrintHospitals(hospital);
                var HospitalDoctors = doctors.Where(doctor => doctor.HospitalID == hospital.HospitalID);
                if(HospitalDoctors.Count() > 0)
                {
                    Console.WriteLine($"{hospital.HospitalName} hospital doctors :");
                    showProvider.PrintDoctors(HospitalDoctors);
                }
                else Console.WriteLine($"0 {hospital.HospitalName} hospital doctors");
            }

        }

        public void GetVisits()
        {
            var visitProvider = new VisitsDataAccess();
            var showProvider = new ShowProvider();
            var visits = visitProvider.GetVisits();

            showProvider.PrintVisits(visits);

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
                int newDoctorID = GetID("Provide doctor ID");

                var doctors = dataProvider.GetDoctors();
                while (doctors.Any(doctor => doctor.DoctorID == newDoctorID))
                {
                    newDoctorID = GetID($"You already have doctor with {newDoctorID} ID");
                }

                newDoctorData.Add(newDoctorID.ToString());

                foreach (var dataQuery in dataToCollect)
                {
                    Console.WriteLine($"Please provide {dataQuery} :");
                    newDoctorData.Add(Console.ReadLine());
                }
                newDoctorData.Add(GetHospitalID().ToString());

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

            Console.WriteLine("Please provide ID of doctor to remove");
            string providedData = Console.ReadLine();
            int DoctorID = Int32.Parse(providedData);
            try
            {
                IEnumerable<Doctor> doctors = dataProvider.GetDoctors();
                Doctor doctorToDelete = doctors.Single(item => item.DoctorID == DoctorID);
                dataProvider.RemoveDoctor(doctorToDelete);
                Console.WriteLine("Successfully removed doctor");
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
                newHospitalData.Add(GetHospitalID().ToString());

                foreach (var dataQuery in dataToCollect)
                {
                    Console.WriteLine($"Please provide {dataQuery} :");
                    newHospitalData.Add(Console.ReadLine());
                }

                Console.WriteLine("Online Prescriptions availability : Yes/No");
                string prescAvailability = Console.ReadLine();
                while(prescAvailability == "Yes" || prescAvailability == "No")
                {
                    Console.WriteLine("Please provide 'Yes' or 'No' :");
                    prescAvailability = Console.ReadLine();
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

            Console.WriteLine("Please provide ID of hospital to remove");
            string providedData = Console.ReadLine();
            int hospitalID = Int32.Parse(providedData);
            try
            {
                IEnumerable<Hospital> hospitals = dataProvider.GetHospitals();
                Hospital hospitalToDelete = hospitals.Single(item => item.HospitalID == hospitalID);
                dataProvider.RemoveHospital(hospitalToDelete);
                Console.WriteLine("Successfully removed hospital");
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

            int visitID = GetID("Provide Visit ID :");

            while(visits.Any(visit=>visit.VisitID == visitID))
            {
                visitID = GetID($"There is already visit with {visitID} ID");
            }
          
            visitData.Add(visitID.ToString());
            visitData.Add(GetID("Provide Hospital ID :").ToString());
            Console.WriteLine("Provide time of visit");
            visitData.Add(Console.ReadLine());

            Visit visit = new Visit(visitData);
            visit.Available = true;
            visitProvider.AddVisit(visit);
        }

        public void RemoveVisit()
        {
            var visitProvider = new VisitsDataAccess();
            int visitID = GetID("Please provide visit ID to remove");

            var visits = visitProvider.GetVisits();
            try
            {
                var VisitToRemove = visits.First(visit => visit.VisitID == visitID);
                visitProvider.RemoveVisit(VisitToRemove);
            }
            catch (Exception)
            {
                Console.WriteLine($"There is no visit with {visitID} to remove");
            }
        }

    }
}
