

namespace HospitalSystem
{
    public class HospitalOptions : View, IHospitalOptions
    {
        public void GetHospitalOptions(int selectedOption)
        {
            _options.PrintAdminOptions();

            int userSelection = GetUserSelection();

            while (userSelection != 5)
            {
                switch (selectedOption)
                {
                    case 1:
                        //Not implemented yet
                        break;
                    case 2:
                        _hospitalControllers.GetHospitalInfo();
                        break;
                    case 3:
                        _hospitalControllers.GetHospitalDoctors();
                        break;
                    case 4:
                        _hospitalControllers.ShowAvailableVisits();
                        break;
                }
            }
        }
    }
}
