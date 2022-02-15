using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public class HospitalsDataProvider : IHospitalDataAccess
    {
        private const string HospitalsFilePath = @".\hospitals.txt";
        private const string separator = "|";

        public void AddHospital(IHospital newHospital)
        {
            InitializeHospitalsFile();
            string line = string.Join(separator, newHospital.ConvertToDataRow());
            File.AppendAllText(HospitalsFilePath, line + Environment.NewLine);
        }

        public IEnumerable<IHospital> GetHospitals()
        {
            InitializeHospitalsFile();

            foreach(string line in File.ReadLines(HospitalsFilePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    List<string> hospitalData = new List<string>(line.Split(separator.ToCharArray()));
                    IHospital newHospital = new Hospital(hospitalData);
                    yield return newHospital;
                }
            }
        }

        public void RemoveHospital(IHospital hospitalToRemove)
        {
            InitializeHospitalsFile();
            var hospitals = GetHospitals().ToList();
            hospitals.Remove(hospitalToRemove);
            File.WriteAllText(HospitalsFilePath, string.Empty);

            AddHospitals(hospitals);
        }

        private void AddHospitals(List<IHospital> hospitals)
        {
            foreach (var hospital in hospitals)
            {
                AddHospital(hospital);
            }
        }

        private void InitializeHospitalsFile()
        {
            if (!File.Exists(HospitalsFilePath))
            {
                using (File.Create(HospitalsFilePath))
                {

                }
            }
        }
    }
}
