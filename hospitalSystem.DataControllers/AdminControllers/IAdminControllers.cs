using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.DataControllers.AdminControllers
{
    public interface IAdminControllers
    {
        public void GetHospitalsAndDoctors();
        public void GetVisits();
        public void AddDoctor();
        public void RemoveDoctor();
        public void AddHospital();
        public void RemoveHospital();
        public void AddVisit();
        public void RemoveVisit();

    }
}
