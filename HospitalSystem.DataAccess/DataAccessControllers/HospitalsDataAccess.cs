using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessControllers
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

        public void AddHospital(Hospital newHospital)
        {
            InitializeHospitalsFile();
            string line = string.Join(separator, newHospital.ConvertToDataRow());
            File.AppendAllText(HospitalsFilePath, line + Environment.NewLine);
        }

        private void AddHospitals(List<Hospital> hospitals)
        {
            foreach (var hospital in hospitals)
            {
                AddHospital(hospital);
            }
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            InitializeHospitalsFile();

            foreach(string line in File.ReadLines(HospitalsFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    List<string> hospitalData = new List<string>(line.Split(separator.ToCharArray()));
                    Hospital newHospital = new Hospital(hospitalData);
                    yield return newHospital;
                }
            }
        }

        public void RemoveHospital(Hospital hospitalToRemove)
        {
            InitializeHospitalsFile();
            var hospitals = GetHospitals().ToList();
            hospitals.Remove(hospitalToRemove);
            File.WriteAllText(HospitalsFilePath, String.Empty);

            AddHospitals(hospitals);
        }

    }
}
