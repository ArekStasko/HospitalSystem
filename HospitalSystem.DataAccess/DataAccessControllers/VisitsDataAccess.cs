using HospitalSystem.DataAccess.models;


namespace HospitalSystem.DataAccess.DataAccessControllers
{
    public class VisitsDataAccess
    {
        private string VisitsFilePath = @".\visits.txt";
        private string separator = "|";

        private void InitializeFile()
        {
            if (!File.Exists(VisitsFilePath))
            {
                using (File.Create(VisitsFilePath))
                {

                }
            }
        }

        public IEnumerable<Visit> GetVisits()
        {
            InitializeFile();

            foreach (var line in File.ReadAllLines(VisitsFilePath))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    List<string> visitData = new List<string>(line.Split(separator.ToCharArray()));
                    Visit visit = new Visit(visitData);
                    visit.Available = visitData[3] == "Yes";
                    if (!visit.Available)
                    {
                        visit.DoctorID = Int32.Parse(visitData[4]);
                        visit.UserID = Int32.Parse(visitData[5]);
                        visit.Description = visitData[6];
                    }
                    yield return visit;
                }
            }
        }

        public void AddVisit(Visit visit)
        {
            InitializeFile();
            string dataToSave;
            if (visit.Available)
            {
                dataToSave = string.Join(separator, visit.MainInfoToDataRow());
            }
            else
            {
                dataToSave = string.Join(separator, visit.AllInfoToDataRow());
            }
            File.AppendAllText(VisitsFilePath, dataToSave + Environment.NewLine);
        }

        public void RemoveVisit(Visit visitToRemove)
        {
            InitializeFile();
            var visits = GetVisits().ToList();
            visits.Remove(visitToRemove);

            File.WriteAllText(VisitsFilePath, String.Empty);

            foreach (var visit in visits)
            {
                AddVisit(visit);
            }
        }

        public void UpdateVisit(Visit visitToUpdate)
        {
            RemoveVisit(visitToUpdate);
            AddVisit(visitToUpdate);
        }

    }
}
