using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public interface IHospitalDataAccess
    {
        public void AddHospital(Hospital newHospital);
        public IEnumerable<Hospital> GetHospitals();
        public void RemoveHospital(Hospital hospitalToRemove);
    }
}
