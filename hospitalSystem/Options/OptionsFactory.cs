

namespace HospitalSystem.Options
{
    public static class OptionsFactory
    {
        public static IAdminOptions GetNewAdminOptionsInstance()
        {
            return new AdminOptions();
        }

        public static IDoctorOptions GetNewDoctorOptionsInstance()
        {
            return new DoctorOptions();
        }

        public static IPatientOptions GetNewPatientOptions()
        {
            return new PatientOptions();
        }

        public static IHospitalOptions GetNewHospitalOptions()
        {
            return new HospitalOptions();
        }
    }
}
