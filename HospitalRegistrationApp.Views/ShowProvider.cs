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

        public void PrintHospitals(IEnumerable<Hospital> hospitals)
        {
            Console.WriteLine("| ID | Hospital Name | Adress | Opening Time | Closing Time | Online Prescriptions |");
            foreach (var hospital in hospitals)
            { 
                PrintItem(hospital.ConvertToDataRow());
                Console.WriteLine("---");
            }
        }

        public void PrintDoctors(IEnumerable<Doctor> doctors)
        {
            foreach (var doctor in doctors)
            {
                PrintItem(doctor.ConvertToDataRow());
                Console.WriteLine("---");
            }
        }

        public void PrintVisit(Visit visit)
        {
            if (visit.Available)
            {
                PrintItem(visit.MainInfoToDataRow());
            }
            else
            {
                PrintItem(visit.AllInfoToDataRow());
            }
        }

        public void PrintVisits(IEnumerable<Visit> visits)
        {
            if (visits.Any())
            {
                Console.WriteLine("| Visit ID | Hospital ID | Time | Available | Doctor ID | User ID | Description |");
                foreach (var visit in visits)
                {
                    PrintVisit(visit);
                    Console.WriteLine("---");
                }
            }
            else
            {
                throw new Exception("There is no visits");
            }
        }
    }
}
