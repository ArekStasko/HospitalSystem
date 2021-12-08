using System;
using System.Collections.Generic;

namespace HospitalRegistrationApp.DataAccess.models
{
    public class Doctor : AbstractModel
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HospitalName { get; set; }

        public Doctor(List<string> doctorData)
        {
            DoctorID = Int32.Parse(doctorData[0]);
            FirstName = doctorData[1];
            LastName = doctorData[2];
            HospitalName = doctorData[3];
        }
        
        public override string[] ConvertToDataRow()
        {
            return new[] {
                DoctorID.ToString(),
                FirstName,
                LastName,
                HospitalName
            };
        }

        protected bool Equals(Doctor other)
        {
            return DoctorID == other.DoctorID;
        }

    }

}
