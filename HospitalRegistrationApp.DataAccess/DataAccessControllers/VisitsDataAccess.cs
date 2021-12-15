using System;
using System.Collections.Generic;
using HospitalRegistrationApp.DataAccess.models;
using System.IO;

namespace HospitalRegistrationApp.DataAccess.DataAccessControllers
{
    public class VisitsDataAccess
    {
        private string FilePath = @".\visits.txt";
        private string separator = "|";

        private void InitializeFile()
        {
            if (!File.Exists(FilePath))
            {
                using (File.Create(FilePath))
                {

                }
            }
        }

        public void AddVisit(Visit visit)
        {
            InitializeFile();
            string dataToSave = string.Join(separator, visit.ConvertToDataRow());
            File.AppendAllText(FilePath, dataToSave + Environment.NewLine);
        }

    }
}
