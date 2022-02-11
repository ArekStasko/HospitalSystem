using HospitalSystem.DataControllers;
using HospitalSystem.DataControllers.PatientControllers;
using HospitalSystem.DataControllers.DoctorControllers;
using HospitalSystem.DataAccess.models;

namespace HospitalSystem
{
    public class View : IView
    {
        static void Main(string[] args)
        {
            var _view = new View();
            _view.Run();
        }

        private void Run()
        {
            OptionsProvider options = new OptionsProvider();
            options.PrintStartingOptions();
            int userSelection;

            do
            {
                userSelection = GetUserSelection();
                Console.Clear();

                switch (userSelection)
                {
                    case 1:
                        PatientController patientController = new PatientController();
                        patientController.SetPatientHospital();
                        break;
                    case 2:
                        DoctorController doctorController = new DoctorController();
                        doctorController.DoctorAuthorization();
                        break;
                    case 3:
                        var adminOptions = new AdminOptions(this);
                        adminOptions.GetAdminOptions();
                        break;
                    default:
                        Console.WriteLine("You selected wrong option number");
                        break;
                };
            } while (userSelection != 4);
            

        }

        public int GetUserSelection()
        {
            string providedData = Console.ReadLine();
            int userSelection;

            while (!Int32.TryParse(providedData, out userSelection))
            {
                Console.WriteLine("Please provide correct data :");
                providedData = Console.ReadLine();
            }

            Console.Clear();
            return userSelection;
        }


        public int GetID(string message)
        {
            Console.WriteLine(message);
            string ID = Console.ReadLine();
            while (!Int32.TryParse(ID, out int n))
            {
                Console.WriteLine("ID must be number");
                ID = Console.ReadLine();
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
    }
}
