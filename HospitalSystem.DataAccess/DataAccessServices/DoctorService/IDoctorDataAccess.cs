using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public interface IDoctorDataAccess
    {
        public void AddDoctor(IDoctor newDoctor);
        public void RemoveDoctor(IDoctor doctorToDelete);
        public IEnumerable<IDoctor> GetDoctors();
        public IEnumerable<IDoctor> GetDoctorsByHospitalID(int ID);
    }
}
