
namespace HospitalSystem.Options.DoctorOptions
{
    public class DoctorOptions : View
    {

        public void GetDoctorOptions()
        {
            _options.PrintDoctorOptions();
            int userSelection = GetUserSelection();

            while (userSelection != 3)
            {
                switch (userSelection)
                {
                    case 1:
                        _doctorControllers.GetDoctorHospital();
                        break;
                    case 2:
                        _doctorControllers.GetDoctorVisits();
                        break;
                    default:
                        Console.WriteLine("You chose wrong option number");
                        break;
                }
                _options.PrintDoctorOptions();
                userSelection = GetUserSelection();
            }

        }
    }
}
