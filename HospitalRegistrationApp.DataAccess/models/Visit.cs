using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalRegistrationApp.DataAccess.models
{
    public class Visit 
    {
        public int VisitID { get; }
        public int HospitalID { get; }
        public bool Available { get; set; }
        public string Time { get; }
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }

        public Visit(List<string> visitData)
        {
            VisitID = Int32.Parse(visitData[0]);
            HospitalID = Int32.Parse(visitData[1]);
            Time = visitData[2];
        }

        public string[] MainInfoToDataRow()
        {
            return new string[]
            {
                VisitID.ToString(),
                HospitalID.ToString(),
                Time,
                Available ? "Yes" : "No"
            };
        }

        public string[] AllInfoToDataRow()
        {
            return new string[]
            {
                VisitID.ToString(),
                HospitalID.ToString(),
                Time,
                Available ? "Yes" : "No",
                DoctorID.ToString(),
                UserID.ToString(),
                Description,
            };
        }

        protected bool Equals(Visit visit)
        {
            return VisitID == visit.VisitID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Visit)obj);
        }

        public override int GetHashCode()
        {
            return VisitID;
        }
    }
}
