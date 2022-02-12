using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.DataControllers.PatientControllers
{
    public interface IPatientControllers
    {
        public void HospitalOptions();
        public void SetPatientHospital();
        public void ShowMyVisits();
        public void SignUpForVisit();
    }
}
