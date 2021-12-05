using System;
using System.Collections.Generic;
using System.Text;
using HospitalRegistrationApp.DataAccess.models;

namespace HospitalRegistrationApp.Views
{
    public class ShowProvider
    {
        private void PrintItem(string[] item)
        {
            Console.WriteLine(String.Join(" | ", item));
        }

        public void PrintHospitals(IEnumerable<Hospital> hospitals)
        {
            Console.WriteLine("All hospitals :");
            
            foreach(var hospital in hospitals)
            {
                PrintItem(hospital.ConvertToDataRow());
            }
        }
    }
}
