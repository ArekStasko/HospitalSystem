using System;
using HospitalRegistrationApp.Views;

namespace HospitalRegistrationApp.DataControllers.AdminControllers
{
    public class AdminController : DataGetController
    {
        public void GetAdminOptions()
        {
            OptionsProvider options = new OptionsProvider();
            options.PrintAdminOptions();

            int userSelection = GetUserSelection();
            Console.Clear();
            Console.WriteLine($"You chosen option number {userSelection}");
        }
    }
}
