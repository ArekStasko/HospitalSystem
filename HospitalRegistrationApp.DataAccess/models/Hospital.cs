using System;
using System.Collections.Generic;

namespace HospitalRegistrationApp.DataAccess.models
{
    public class Hospital : AbstractModel
    {
        public int HospitalID { get; }
        public bool IsOnlinePrescriptions { get; }
        public string HospitalAdress { get; }
        public string HospitalOpeningTime { get; }
        public string HospitalClosingTime { get; }
        public string HospitalName { get; }

        public Hospital(List<string> hospitalData)
        {
            HospitalID = Int32.Parse(hospitalData[0]);
            HospitalName = hospitalData[1];
            IsOnlinePrescriptions = hospitalData[2] == "Yes";
            HospitalAdress = hospitalData[3];
            HospitalOpeningTime = hospitalData[4];
            HospitalClosingTime = hospitalData[5];
        }

        public override string[] ConvertToDataRow()
        {
            return new[] { 
                HospitalID.ToString(), 
                HospitalName,
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Hospital)obj);
        }

        public override int GetHashCode()
        {
            return HospitalID;
        }
    }
}
