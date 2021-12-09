using System;
using System.Collections.Generic;

namespace HospitalRegistrationApp.DataAccess.models
{
    public class Doctor : AbstractModel
    {
        public int DoctorID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int HospitalID { get; }
        

        public Doctor(List<string> doctorData)
        {
            DoctorID = Int32.Parse(doctorData[0]);
            FirstName = doctorData[1];
            LastName = doctorData[2];
            HospitalID = Int32.Parse(doctorData[3]);
        }
        
        public override string[] ConvertToDataRow()
        {
            return new[] {
                DoctorID.ToString(),
                FirstName,
                LastName,
                HospitalID.ToString()
            };
        }

        protected bool Equals(Doctor other)
        {
            return DoctorID == other.DoctorID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Doctor)obj);
        }

        public override int GetHashCode()
        {
            return DoctorID;
        }
    }

}
