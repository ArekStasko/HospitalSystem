
namespace HospitalSystem.Options.PatientOptions
{
    public class PatientOptions : View
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
                        
                        break;
                    case 2:
                        _patientControllers.ShowMyVisits();
                        break;
                    case 3:
                        Console.Clear();
                        _patientControllers.SignUpForVisit();
                        break;
                }

            } while (selectedOption != 4);

        }

    }
}
