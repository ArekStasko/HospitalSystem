using HospitalSystem.DataControllers;
using HospitalSystem.Options;
using HospitalSystem.DataControllers.PatientControllers;
using HospitalSystem.DataControllers.DoctorControllers;
using HospitalSystem.DataControllers.AdminControllers;
using HospitalSystem.DataControllers.HospitalControllers;
using HospitalSystem.DataAccess.models;

namespace HospitalSystem
{
    public class View : IView
    {
        protected OptionsProvider _options = new OptionsProvider();
        protected IVisitControllers _visitControllers;
        protected IPatientControllers _patientControllers;
        protected IDoctorControllers _doctorControllers;
        protected IHospitalControllers _hospitalControllers;

        public View()
        {
            _visitControllers = ControllersFactory.NewAdminControllersInstance(this);
            _patientControllers = ControllersFactory.NewPatientControllersInstance(this);
            _doctorControllers = ControllersFactory.NewDoctorControllersInstance(this);
            _hospitalControllers = ControllersFactory.NewHospitalControllersInstance(this);
        }

        private void Run()
        {
            _options.PrintStartingOptions();
            int userSelection;

            do
            {
                userSelection = GetUserSelection();
                Console.Clear();

                switch (userSelection)
                {
                    case 1:
                        var patientOptions = OptionsFactory.GetNewPatientOptions();
                        patientOptions.GetPatientOptions();
                        break;
                    case 2:;
                        var doctorOptions = OptionsFactory.GetNewDoctorOptionsInstance();
                        doctorOptions.GetDoctorOptions();
                        break;
                    case 3:
                        var adminOptions = OptionsFactory.GetNewAdminOptionsInstance();
                        adminOptions.GetAdminOptions();
                        break;
                    default:
                        Console.WriteLine("You selected wrong option number");
                        break;
                };
            } while (userSelection != 4);            

        }
        
        public void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public string GetData()
        {
            string data;
            do
            {
                data = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(data));
            return data;
        }

        public int GetUserSelection()
        {
            string providedData = GetData();
            int userSelection;

            while (!Int32.TryParse(providedData, out userSelection))
            {
                Console.WriteLine("Please provide correct data :");
                providedData = GetData();
            }

            Console.Clear();
            return userSelection;
        }


        public int GetID()
        {
            string ID = GetData();
            while (!Int32.TryParse(ID, out int n))
            {
                Console.WriteLine("ID must be number");
                ID = GetData();
            }
            Console.Clear();
            return Int32.Parse(ID);
        }

        public void PrintHospitals(Hospital hospital)
        {
            Console.WriteLine("---");
            Console.WriteLine("| ID | Hospital Name | Adress | Opening Time | Closing Time | Online Prescriptions |");
            PrintItem(hospital.ConvertToDataRow());
        }

        public void PrintHospitals(IEnumerable<Hospital> hospitals)
        {
            Console.WriteLine("| ID | Hospital Name | Adress | Opening Time | Closing Time | Online Prescriptions |");
            foreach (var hospital in hospitals)
            {
                PrintItem(hospital.ConvertToDataRow());
                Console.WriteLine("---");
            }
        }

        public void PrintDoctors(IEnumerable<Doctor> doctors)
        {
            foreach (var doctor in doctors)
            {
                PrintItem(doctor.ConvertToDataRow());
                Console.WriteLine("---");
            }
        }

        public void PrintVisit(Visit visit)
        {
            if (visit.Available)
            {
                PrintItem(visit.MainInfoToDataRow());
            }
            else
            {
                PrintItem(visit.AllInfoToDataRow());
            }
        }

        public void PrintVisits(IEnumerable<Visit> visits)
        {
            if (visits.Any())
            {
                Console.WriteLine("| Visit ID | Hospital ID | Time | Available | Doctor ID | User ID | Description |");
                foreach (var visit in visits)
                {
                    PrintVisit(visit);
                    Console.WriteLine("---");
                }
            }
            else
            {
                throw new Exception("There is no visits");
            }
        }

        private void PrintItem(string[] item)
        {
            Console.WriteLine(String.Join(" | ", item));
        }

        static void Main(string[] args)
        {
            var _view = new View();
            _view.Run();
        }
    }
}
