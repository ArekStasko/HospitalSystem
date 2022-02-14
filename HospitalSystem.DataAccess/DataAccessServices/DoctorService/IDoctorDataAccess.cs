using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public interface IDoctorDataAccess
    {
        public void AddDoctor(Doctor newDoctor);
        public void RemoveDoctor(Doctor doctorToDelete);
        public IEnumerable<Doctor> GetDoctors();
        public IEnumerable<Doctor> GetDoctorsByHospitalID(int ID);
    }
}
