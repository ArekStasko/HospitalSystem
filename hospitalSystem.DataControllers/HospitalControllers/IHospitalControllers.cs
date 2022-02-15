using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers.HospitalControllers
{
    public interface IHospitalControllers
    {
        public IEnumerable<IHospital> GetHospitals();
        public IHospital GetHospital();
        public IEnumerable<IDoctor> GetHospitalDoctors();
        public IEnumerable<IVisit> GetAvailableVisits();

    }
}
