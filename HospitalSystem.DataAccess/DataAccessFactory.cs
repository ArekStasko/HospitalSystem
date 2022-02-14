using HospitalSystem.DataAccess.DataAccessServices;
using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess
{
    public static class DataAccessFactory
    {
        public static IDoctor GetDoctorInstance(List<string> data)
        {
            return new Doctor(data);
        }

        public static IHospital GetHospitalInstance(List<string> data)
        {
            return new Hospital(data);
        }

        public static IVisit GetVisitInstance(List<string> data)
        {
            return new Visit(data);
        }

        public static IDoctorDataAccess GetNewDoctorDataAccessInstance()
        {
            return new DoctorDataProvider();
        }

        public static IHospitalDataAccess GetNewHospitalDataAccessInstance()
        {
            return new HospitalsDataProvider();
        }

        public static IVisitDataAccess GetNewVisitDataAccessInstance()
        {
            return new VisitsDataAccess();
        }


    }
}
