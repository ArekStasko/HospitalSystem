using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.DataControllers.HospitalControllers
{
    public interface IHospitalControllers
    {
        public void GetHospitalOptions(int selectedOption);
        public void GetHospitalInfo();
        public void GetHospitalDoctors();
        public void ShowAvailableVisits();

    }
}
