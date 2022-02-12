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
        public void PrintHospitals(Hospital hospital);
        public void PrintHospitals(IEnumerable<Hospital> hospitals);
        public void PrintDoctors(IEnumerable<Doctor> doctors);
        public void PrintVisit(Visit visit);
        public void PrintVisits(IEnumerable<Visit> visits);
        public void PrintMessage(string msg);
        public string GetData();

    }
}
