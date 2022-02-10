
namespace HospitalSystem.Views
{
    public class OptionsProvider : IOptionsProvider
    {
        public void PrintStartingOptions()
        {
            string[] startingOptions = new string[]{ "Patient", "Doctor", "Admin" };

            Console.WriteLine("You want to login as :");
            PrintOptions(startingOptions);
        }

        public void PrintAdminOptions()
        {
            string[] adminOptions = new string[] 
            { 
                "Show Hospitals with Doctors", 
                "Show Visits",
                "Add Doctor", 
                "Remove Doctor", 
                "Add Hospital", 
                "Remove Hospital",
                "Add Visit",
                "Remove visit",
                "Close System"
            };
            PrintOptions(adminOptions);
        }

        public void PrintDoctorOptions()
        {
            string[] doctorOptions = new string[]
            {
                "Show my hospital",
                "Show visits assigned to me",
                "Close System"
            };
            PrintOptions(doctorOptions);
        }

        public void PrintPatientOptions()
        {
            string[] patientOptions = new string[]
            {
                "Show hospital options",
                "Show my visits",
                "Sign up for visit",
                "Close System"
            };
            PrintOptions(patientOptions);
        }

        public void PrintHospitalOptions()
        {
            string[] hospitalOptions = new string[]
            {
                "Change my hospital",
                "Show main info about my hospital",
                "Show doctors assinged to my hospital",
                "Show available visits"
            };
            PrintOptions(hospitalOptions);
        }

        private void PrintOptions(string[] options)
        {
            Console.WriteLine("What do you want to do ? :");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine("Choose number of option :");
        }
    }
}
