using System;
using System.Collections.Generic;
using HospitalRegistrationApp.Views;
using HospitalRegistrationApp.DataAccess;
using HospitalRegistrationApp.DataAccess.models;

namespace HospitalRegistrationApp.DataControllers.AdminControllers
{
    public class AdminController : DataGetController
    {
        private void getHospitals()
        {
            var dataProvider = new DataProvider();
            var hospitals = dataProvider.GetHospitals();

            var showProvider = new ShowProvider();
            showProvider.PrintHospitals(hospitals);
        }

        private void AddHospital()
        {
            List<string> newHospitalData = new List<string>() { };
            string[] dataToCollect = new string[] { 
                "Hospital ID",
                "Online Prescriptions availability : Yes/No", 
                "Hospital Adress", 
                "Hospital Opening Time", 
                "Hospital Closing time" 
            };

            // TODO: add defensive programming validation
            foreach(var data in dataToCollect)
            {
                Console.WriteLine($"Please provide {data} :");
                newHospitalData.Add(Console.ReadLine());
            }

            var hospital = new Hospital()
            {
                HospitalID = Int32.Parse(newHospitalData[0]),
                IsOnlinePrescriptions = newHospitalData[1] == "Yes",
                HospitalAdress = newHospitalData[2],
                HospitalOpeningTime = newHospitalData[3],
                HospitalClosingTime = newHospitalData[4]
            };

            var dataProvider = new DataProvider();
            dataProvider.AddHospital(hospital);
        }

        public void GetAdminOptions()
        {
            OptionsProvider options = new OptionsProvider();
            options.PrintAdminOptions();

            int userSelection = GetUserSelection();
            Console.Clear();

            if (userSelection == 1)
            {

            }
            else if (userSelection == 2)
            {

            }
            else if (userSelection == 3)
            {
                AddHospital();
                getHospitals();
            }
            else if (userSelection == 4)
            {

            }
        }
    }
}
