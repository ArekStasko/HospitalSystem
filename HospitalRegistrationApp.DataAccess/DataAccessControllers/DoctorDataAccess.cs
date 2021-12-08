using System;
using System.Collections.Generic;
using System.IO;
using HospitalRegistrationApp.DataAccess.models;

namespace HospitalRegistrationApp.DataAccess.DataAccessControllers
{
    public class DoctorDataAccess
    {
        private const string DoctorsFilePath = @".\doctors.txt";
        private const string separator = "|";

        private void InitializeDoctorsFile()
        {
            if (!File.Exists(DoctorsFilePath))
            {
                using (File.Create(DoctorsFilePath))
                {

                }
            }
        }

        public void AddDoctor(Doctor newDoctor)
        {
            InitializeDoctorsFile();
            string line = string.Join(separator, newDoctor.ConvertToDataRow());
            File.AppendAllText(DoctorsFilePath, line + Environment.NewLine);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            InitializeDoctorsFile();

            foreach(var line in File.ReadAllLines(DoctorsFilePath))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    List<string> doctorData = new List<string>(line.Split(separator.ToCharArray()));
                    Doctor doctor = new Doctor(doctorData);
                    yield return doctor;
                }
            }

        } 
    }
}
