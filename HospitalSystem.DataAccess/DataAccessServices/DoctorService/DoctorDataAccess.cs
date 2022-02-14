using HospitalSystem.DataAccess.models;
using HospitalSystem.DataAccess.DataAccessServices;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public class DoctorDataProvider : IDoctorDataAccess
    {
        private const string DoctorsFilePath = @".\doctors.txt";
        private const string separator = "|";

        public void AddDoctor(Doctor newDoctor)
        {
            InitializeDoctorsFile();
            string line = string.Join(separator, newDoctor.ConvertToDataRow());
            File.AppendAllText(DoctorsFilePath, line + Environment.NewLine);
        }

        public void RemoveDoctor(Doctor doctorToDelete)
        {
            InitializeDoctorsFile();
            var doctors = GetDoctors().ToList();
            doctors.Remove(doctorToDelete);
            File.WriteAllText(DoctorsFilePath, String.Empty);

            AddDoctors(doctors);
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            InitializeDoctorsFile();

            foreach(string line in File.ReadLines(DoctorsFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    List<string> doctorData = new List<string>(line.Split(separator.ToCharArray()));
                    Doctor newDoctor = new Doctor(doctorData);
                    yield return newDoctor;
                }
            }

        }

        public IEnumerable<Doctor> GetDoctorsByHospitalID(int ID)
        {
            InitializeDoctorsFile();

            var doctors = GetDoctors();
            return doctors.Where(doctor => doctor.HospitalID == ID); ;
        }
        private void AddDoctors(List<Doctor> doctorsToAdd)
        {
            foreach (var doctor in doctorsToAdd)
            {
                AddDoctor(doctor);
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
    }
}
