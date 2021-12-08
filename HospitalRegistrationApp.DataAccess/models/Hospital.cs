using System;
using System.Collections.Generic;

namespace HospitalRegistrationApp.DataAccess.models
{
    public class Hospital : AbstractModel
    {
        public int HospitalID { get; set; }
        public bool IsOnlinePrescriptions { get; set; }
        public string HospitalAdress { get; set; }
        public string HospitalOpeningTime { get; set; }
        public string HospitalClosingTime { get; set; }

        public Hospital(List<string> hospitalData)
        {
            HospitalID = Int32.Parse(hospitalData[0]);
            IsOnlinePrescriptions = hospitalData[1] == "Yes";
            HospitalAdress = hospitalData[2];
            HospitalOpeningTime = hospitalData[3];
            HospitalClosingTime = hospitalData[4];
        }

        public override string[] ConvertToDataRow()
        {
            return new[] { 
                HospitalID.ToString(), 
                IsOnlinePrescriptions ? "Yes" : "No", 
                HospitalAdress,
                HospitalOpeningTime,
                HospitalClosingTime
            };
        }

        protected bool Equals(Hospital other)
        {
            return HospitalID == other.HospitalID;
        }
    }
}
