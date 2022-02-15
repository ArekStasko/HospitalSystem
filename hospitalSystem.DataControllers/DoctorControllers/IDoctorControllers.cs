using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers.DoctorControllers
{
    public interface IDoctorControllers
    {
        public void DoctorAuthorization();
        public IEnumerable<IDoctor> GetDoctors();
        public IHospital GetDoctorHospital();
        public IEnumerable<IVisit> GetDoctorVisits();
    }
}
