using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers
{
    public interface IView
    {
        public int GetUserSelection();
        public int GetID();
        public void PrintHospitals(IHospital hospital);
        public void PrintHospitals(IEnumerable<IHospital> hospitals);
        public void PrintDoctors(IEnumerable<IDoctor> doctors);
        public void PrintVisit(IVisit visit);
        public void PrintVisits(IEnumerable<IVisit> visits);
        public void PrintMessage(string msg);
        public string GetData();

    }
}
