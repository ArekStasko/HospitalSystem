using System;
using System.IO;
using System.Linq;
using HospitalRegistrationApp.DataAccess.models;
using System.Collections.Generic;

namespace HospitalRegistrationApp.DataAccess.DataAccessControllers
{
    public class HospitalsDataProvider
    {
        private const string HospitalsFilePath = @".\hospitals.txt";
        private const string separator = "|";

        private void InitializeHospitalsFile()
        {
            if (!File.Exists(HospitalsFilePath))
            {
                using (File.Create(HospitalsFilePath))
                {

                }
            }
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            InitializeHospitalsFile();

            foreach(var line in File.ReadLines(HospitalsFilePath))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    List<string> hospitalData = new List<string>(line.Split(separator.ToCharArray()));
                    Hospital newHospital = new Hospital(hospitalData);
                    yield return newHospital;
                }
            }
        }

        public void AddHospital(Hospital newHospital)
        {
            InitializeHospitalsFile();
            string line = string.Join(separator, newHospital.ConvertToDataRow());
            File.AppendAllText(HospitalsFilePath, line + Environment.NewLine);
        }

        public void AddHospitals(List<Hospital> hospitals)
        {
            foreach(var hospital in hospitals)
            {
                AddHospital(hospital);
            }
        }

        public void RemoveHospital(Hospital hospitalToRemove)
        {
            InitializeHospitalsFile();
            var hospitals = GetHospitals().ToList();
            hospitals.Remove(hospitalToRemove);
            File.WriteAllText(HospitalsFilePath, String.Empty);

            foreach(var hospital in hospitals)
            {
                Console.WriteLine(hospital.HospitalID);
                Console.WriteLine($"hospital to remove: {hospitalToRemove.HospitalID}");
            }

            AddHospitals(hospitals);
        }

    }
}
