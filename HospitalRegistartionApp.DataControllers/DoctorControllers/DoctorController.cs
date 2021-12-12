using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.Views;
using System;
using System.Linq;

namespace HospitalRegistrationApp.DataControllers.DoctorControllers
{
    public class DoctorController : DataGetController
    {
        private int DoctorID { get; set; }
        public void DoctorAuthorization()
        {
            var dataProvider = new DoctorDataProvider();
            int doctorID = GetID("Please provide your ID :");

            var doctors = dataProvider.GetDoctors();
            if(doctors.Any(doctor => doctor.DoctorID == doctorID))
            {
                DoctorID = doctorID;
                Console.WriteLine($"You are logged in as {doctorID} doctor");
                GetDoctorOptions();
            }
            else
            {
                Console.WriteLine($"There are no doctor with {doctorID} ID");
            }
        }

        private void GetDoctorOptions()
        {
            var options = new OptionsProvider();
            options.PrintDoctorOptions();
            int userSelection = GetUserSelection();

            switch (userSelection)
            {
                case 1:
                    Console.WriteLine("You chose option number 1");
                    break;
                case 2:
                    Console.WriteLine("You chose option number 2");
                    break;
                default:
                    Console.WriteLine("You chose wrong option number");
                    break;
            }
        }
    }
}
