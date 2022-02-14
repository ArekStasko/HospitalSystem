
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
                        _adminControllers.GetHospitalsAndDoctors();
                        break;
                    case 2:
                        _adminControllers.GetVisits();
                        break;
                    case 3:
                        Console.Clear();
                        _adminControllers.AddDoctor();
                        break;
                    case 4:
                        Console.Clear();
                        _adminControllers.RemoveDoctor();
                        break;
                    case 5:
                        Console.Clear();
                        _adminControllers.AddHospital();
                        break;
                    case 6:
                        Console.Clear();
                        _adminControllers.RemoveHospital();
                        break;
                    case 7:
                        Console.Clear();
                        _adminControllers.AddVisit();
                        break;
                    case 8:
                        Console.Clear();
                        _adminControllers.RemoveVisit();
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
