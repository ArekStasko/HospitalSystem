using System;
using System.Collections.Generic;

namespace HospitalRegistrationApp.Views
{
    public class OptionsProvider : IOptionsProvider
    {
        private void PrintOptions(List<string> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }

        public void PrintStartingOptions()
        {
            List<string> startingOptions = new List<string>() { "Patient", "Doctor", "Admin" };

            Console.WriteLine("You want to login as :");
            PrintOptions(startingOptions);
            Console.WriteLine("Choose number of option :");
        }

        public void PrintAdminOptions()
        {
            List<string> adminOptions = new List<string>() { "Add Doctor", "Remove Doctor", "Add Hospital", "Remove Hospital" };

            Console.WriteLine("What do you want to do ? :");
            PrintOptions(adminOptions);
            Console.WriteLine("Choose number of option :");
        }
    }
}
