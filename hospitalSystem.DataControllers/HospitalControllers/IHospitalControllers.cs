using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers.HospitalControllers
{
    public interface IHospitalControllers
    {
        public IEnumerable<IHospital> GetHospitals();
        public IHospital GetHospital();
        public void SetHospital();
        public IEnumerable<IDoctor> GetHospitalDoctors();
        public IEnumerable<IVisit> GetAvailableVisits();
        public void AddHospital();
        public void RemoveHospital();
    }
}
