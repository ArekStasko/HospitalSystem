using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.DataAccess.models
{
    public interface IDoctor
    {
        public int DoctorID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int HospitalID { get; }
        public string[] ConvertToDataRow();
    }
}
