
namespace HospitalSystem.Views
{
    public interface IOptionsProvider
    {
        public void PrintStartingOptions();
        public void PrintAdminOptions();
        public void PrintDoctorOptions();
        public void PrintPatientOptions();
        public void PrintHospitalOptions();

    }
}
