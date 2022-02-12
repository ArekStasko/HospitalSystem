using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.DataControllers.DoctorControllers
{
    public interface IDoctorControllers
    {
        public void DoctorAuthorization();
        public void GetDoctorHospital();
        public void GetDoctorVisits();
    }
}
