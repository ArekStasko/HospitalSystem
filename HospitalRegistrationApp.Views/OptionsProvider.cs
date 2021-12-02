using System;
using System.Collections.Generic;

namespace HospitalRegistrationApp.Views
{
    public class OptionsProvider : IOptionsProvider
    {

        public void ShowStartingOptions()
        {
            List<string> startingOptions = new List<string>() { "Patient", "Doctor", "Admin" };

            Console.WriteLine("You want to login as :");
            for (int i = 0; i < startingOptions.Count; i++)
            {
                Console.WriteLine($"{i+1}. {startingOptions[i]}");
            }
            Console.WriteLine("Choose number of option :");
        }

    }
}
