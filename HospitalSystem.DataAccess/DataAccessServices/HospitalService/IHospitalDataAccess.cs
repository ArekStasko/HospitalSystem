using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public interface IHospitalDataAccess
    {
        public void AddHospital(IHospital newHospital);
        public IEnumerable<IHospital> GetHospitals();
        public void RemoveHospital(IHospital hospitalToRemove);
    }
}
