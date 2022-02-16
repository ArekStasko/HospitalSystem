using HospitalSystem.Options;

namespace HospitalSystem
{
    public class PatientOptions : View, IPatientOptions
    {
        
        public void GetPatientOptions()
        {
            int selectedOption;

            do
            {
                _options.PrintPatientOptions();
                selectedOption = GetUserSelection();

                switch (selectedOption)
                {
                    case 1:
                        _options.PrintHospitalOptions();
                        var hospitalOptions = OptionsFactory.GetNewHospitalOptions();
                        hospitalOptions.GetHospitalOptions();
                        break;
                    case 2:
                        _visitControllers.GetMyVisits();
                        break;
                    case 3:
                        Console.Clear();
                        _visitControllers.SignUpForVisit();
                        break;
                }

            } while (selectedOption != 4);

        }

    }
}
