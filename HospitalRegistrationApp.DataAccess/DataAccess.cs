using System;
using System.IO;
using HospitalRegistrationApp.DataAccess.models;
using System.Collections.Generic;

namespace HospitalRegistrationApp.DataAccess
{
    public class DataProvider
    {
        private const string HospitalsFilePath = @"hospitals.txt";
        private const string DoctorsFilePath = @"doctors.txt";
        private const string VisitsFilePath = @"visits.txt";
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
        private void InitializeDoctorsFile()
        {
            if (!File.Exists(DoctorsFilePath))
            {
                using (File.Create(DoctorsFilePath))
                {

                }
            }
        }

        private void InitializeVisitsFile()
        {
            if (!File.Exists(VisitsFilePath))
            {
                using (File.Create(VisitsFilePath))
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
                    string[] hospitalData = line.Split(separator.ToCharArray());
                    Hospital newHospital = new Hospital()
                    {
                        HospitalID = Int32.Parse(hospitalData[0]),
                        IsOnlinePrescriptions = hospitalData[1] == "Yes",
                        HospitalAdress = hospitalData[2],
                        HospitalOpeningTime = hospitalData[3],
                        HospitalClosingTime = hospitalData[4]
                    };
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

    }
}
