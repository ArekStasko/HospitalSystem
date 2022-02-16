
namespace HospitalSystem
{
    public class AdminOptions : View, IAdminOptions
    {

        public void GetAdminOptions() 
        {
            _options.PrintAdminOptions();
            
            int userSelection = GetUserSelection();

            while (userSelection != 9)
            {
                switch (userSelection)
                {
                    case 1:
                        var hospitals = _hospitalControllers.GetHospitals();
                        PrintHospitals(hospitals);
                        var doctors = _doctorControllers.GetDoctors();
                        PrintDoctors(doctors);
                        break;
                    case 2:
                        var visits = _visitControllers.GetVisits();
                        PrintVisits(visits);
                        break;
                    case 3:
                        Console.Clear();
                        _doctorControllers.AddDoctor();
                        break;
                    case 4:
                        Console.Clear();
                        _doctorControllers.RemoveDoctor();
                        break;
                    case 5:
                        Console.Clear();
                        _hospitalControllers.AddHospital();
                        break;
                    case 6:
                        Console.Clear();
                        _hospitalControllers.RemoveHospital();
                        break;
                    case 7:
                        Console.Clear();
                        _visitControllers.AddVisit();
                        break;
                    case 8:
                        Console.Clear();
                        _visitControllers.RemoveVisit();
                        break;
                    default:
                        Console.WriteLine("You chose wrong option number");
                        break;
                }
                _options.PrintAdminOptions();
                userSelection = GetUserSelection();
            }

        }

    }
}
