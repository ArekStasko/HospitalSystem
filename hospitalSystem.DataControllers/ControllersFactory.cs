using HospitalSystem.DataControllers.AdminControllers;
using HospitalSystem.DataControllers.DoctorControllers;
using HospitalSystem.DataControllers.HospitalControllers;

namespace HospitalSystem.DataControllers
{
    public static class ControllersFactory
    {
        public static IVisitControllers NewVisitControllersInstance(this IView view)
        {
            return new VisitControllers(view);
        }

        public static IDoctorControllers NewDoctorControllersInstance(this IView view)
        {
            return new DoctorController(view);
        }

        public static IHospitalControllers NewHospitalControllersInstance(this IView view)
        {
            return new HospitalController(view);
        }

    }
}
