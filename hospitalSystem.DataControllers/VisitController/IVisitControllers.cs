using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers.AdminControllers
{
    public interface IVisitControllers
    {
        public void GetHospitalsAndDoctors();
        public IEnumerable<IVisit> GetVisits();
        public void AddDoctor();
        public void RemoveDoctor();
        public void AddHospital();
        public void RemoveHospital();
        public void AddVisit();
        public void RemoveVisit();

    }
}
