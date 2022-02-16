

namespace HospitalSystem
{
    public class HospitalOptions : View, IHospitalOptions
    {
        public void GetHospitalOptions()
        {
            _options.PrintHospitalOptions();
            int userSelection = GetUserSelection();

            while (userSelection != 5)
            {
                _options.PrintHospitalOptions();
                userSelection = GetUserSelection();
                switch (userSelection)
                {
                    case 1:
                        _hospitalControllers.SetHospital();
                        break;
                    case 2:
                        var hospital = _hospitalControllers.GetHospital();
                        PrintHospitals(hospital);
                        break;
                    case 3:
                        var doctors = _hospitalControllers.GetHospitalDoctors();
                        PrintDoctors(doctors);
                        break;
                    case 4:
                        var visits = _hospitalControllers.GetAvailableVisits();
                        PrintVisits(visits);
                        break;
                }
            }
        }
    }
}
