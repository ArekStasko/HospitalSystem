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
            HospitalAdress = hospitalData[2];
            HospitalOpeningTime = hospitalData[3];
            HospitalClosingTime = hospitalData[4];
            IsOnlinePrescriptions = hospitalData[5] == "Yes";
        }

        public override string[] ConvertToDataRow()
        {
            return new[] { 
                HospitalID.ToString(), 
                HospitalName,
                HospitalAdress,
                HospitalOpeningTime,
                HospitalClosingTime,
                IsOnlinePrescriptions ? "Yes" : "No"
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
