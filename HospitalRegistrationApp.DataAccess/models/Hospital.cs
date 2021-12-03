using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalRegistrationApp.DataAccess.models
{
    public class Hospital : AbstractModel
    {
        public int HospitalID { get; set; }
        public bool IsOnlinePrescriptions { get; set; }
        public string HospitalAdress { get; set; }
        public string HospitalOpeningTime { get; set; }
        public string HospitalClosingTime { get; set; }

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
    }
}
