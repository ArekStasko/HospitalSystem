using HospitalSystem.DataControllers.AdminControllers;
using HospitalSystem.DataControllers.PatientControllers;
using HospitalSystem.DataControllers.DoctorControllers;
using HospitalSystem.DataControllers.HospitalControllers;

namespace HospitalSystem.DataControllers
{
    public static class ControllersFactory
    {
        public static IAdminControllers NewAdminControllersInstance(this IView view)
        {
            return new AdminController(view);
        }

        public static IPatientControllers NewPatientControllersInstance(this IView view)
        {
            return new PatientController(view);
        }

        public static IDoctorControllers NewDoctorControllersInstance(this IView view)
        {
            return new DoctorController(view);
        }

        public static IHospitalControllers NewHospitalControllersInstance(int HospitalID)
        {
            return new HospitalController(HospitalID);
        }

    }
}
