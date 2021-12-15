using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalRegistrationApp.DataAccess.models
{
    public class Visit
    {
        public int VisitID { get; }
        public int HospitalID { get; }
        public bool Available { get; }
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }

   
        public Visit(List<int> visitData)
        {
            VisitID = visitData[0];
            HospitalID = visitData[1];
            Available = true;
        }

        public Visit(List<string> visitData)
        {
            VisitID = Int32.Parse(visitData[0]);
            HospitalID = Int32.Parse(visitData[1]);
            Available = true;
        }

        public string[] MainInfoToDataRow()
        {
            return new string[]
            {
                VisitID.ToString(),
                HospitalID.ToString(),
                Available ? "Yes" : "No",
            };
        }

        public string[] AllInfoToDataRow()
        {
            return new string[]
            {
                VisitID.ToString(),
                HospitalID.ToString(),
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
