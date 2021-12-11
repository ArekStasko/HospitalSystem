using System;
using System.Collections.Generic;
using System.Text;
using HospitalRegistrationApp.DataAccess.models;
using System.Linq;

namespace HospitalRegistrationApp.Views
{
    public class ShowProvider
    {
        private void PrintItem(string[] item)
        {
            Console.WriteLine(String.Join(" | ", item));
        }

        public void PrintHospitals(Hospital hospital)
        {
            Console.WriteLine("---");
            Console.WriteLine("| ID | Hospital Name | Adress | Opening Time | Closing Time | Online Prescriptions |");
            PrintItem(hospital.ConvertToDataRow());
        }

        public void PrintDoctors(IEnumerable<Doctor> doctors)
        {
            foreach (var doctor in doctors)
            {
                PrintItem(doctor.ConvertToDataRow());
            }
        }
    }
}
