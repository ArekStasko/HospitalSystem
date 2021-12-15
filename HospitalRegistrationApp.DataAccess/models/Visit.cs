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
        public string description { get; set; }

   
        public Visit(List<int> visitData)
        {
            VisitID = visitData[0];
            HospitalID = visitData[1];
            Available = true;
        }

        public string[] ConvertToDataRow()
        {
            return new string[]
            {
                VisitID.ToString(),
                HospitalID.ToString(),
                Available ? "accessible" : "inaccessible",
            };
        }
    }
}
