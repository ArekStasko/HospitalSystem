using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.DataControllers;
using HospitalSystem.DataControllers.AdminControllers;

namespace HospitalSystem
{
    public class AdminOptions : OptionsProvider
    {
        private IView _view;

        public AdminOptions(IView view) => _view = view;

        public void GetAdminOptions() 
        {
            PrintAdminOptions();

            int userSelection = _view.GetUserSelection();

            var adminControllers = new AdminController(_view);

            while (userSelection != 9)
            {
                switch (userSelection)
                {
                    case 1:
                        adminControllers.GetHospitalsAndDoctors();
                        break;
                    case 2:
                        adminControllers.GetVisits();
                        break;
                    case 3:
                        Console.Clear();
                        adminControllers.AddDoctor();
                        break;
                    case 4:
                        Console.Clear();
                        adminControllers.RemoveDoctor();
                        break;
                    case 5:
                        Console.Clear();
                        adminControllers.AddHospital();
                        break;
                    case 6:
                        Console.Clear();
                        adminControllers.RemoveHospital();
                        break;
                    case 7:
                        Console.Clear();
                        adminControllers.AddVisit();
                        break;
                    case 8:
                        Console.Clear();
                        adminControllers.RemoveVisit();
                        break;
                    default:
                        Console.WriteLine("You chose wrong option number");
                        break;
                }
                PrintAdminOptions();
                userSelection = _view.GetUserSelection();
            }

        }

    }
}
