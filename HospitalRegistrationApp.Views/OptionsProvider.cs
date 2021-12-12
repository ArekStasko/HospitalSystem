using System;
using System.Collections.Generic;

namespace HospitalRegistrationApp.Views
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
                "Add Doctor", 
                "Remove Doctor", 
                "Add Hospital", 
                "Remove Hospital" 
            };

            Console.WriteLine("What do you want to do ? :");
            PrintOptions(adminOptions);
        }

        public void PrintDoctorOptions()
        {
            string[] doctorOptions = new string[]
            {
                "Show my hospital",
                "Show visits assigned to me"
            };
            Console.WriteLine("What do you want to do ?");
            PrintOptions(doctorOptions);
        }

        private void PrintOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine("Choose number of option :");
        }
    }
}
