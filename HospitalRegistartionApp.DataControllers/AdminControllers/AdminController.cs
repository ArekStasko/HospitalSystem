using System;
using System.Collections.Generic;
using System.Linq;
using HospitalRegistrationApp.Views;
using HospitalRegistrationApp.DataAccess.DataAccessControllers;
using HospitalRegistrationApp.DataAccess.models;

namespace HospitalRegistrationApp.DataControllers.AdminControllers
{
    public class AdminController : DataGetController
    {

        public void GetAdminOptions()
        {
            OptionsProvider options = new OptionsProvider();
            options.PrintAdminOptions();

            int userSelection = GetUserSelection();
            Console.Clear();

            switch (userSelection)
            {
                case 1:
                    AddDoctor();
                    GetDoctors();
                    break;
                case 2:
                    RemoveDoctor();
                    break;
                case 3:
                    AddHospital();
                    GetHospitals();
                    break;
                case 4:
                    RemoveHospital();
                    break;
            }

        }

        private void GetDoctors()
        {
            var dataProvider = new DoctorDataAccess();
            var doctors = dataProvider.GetDoctors();

            var showProvider = new ShowProvider();
            showProvider.PrintDoctors(doctors);
        }

        private void AddDoctor()
        {
            var dataProvider = new DoctorDataAccess();
            List<string> newDoctorData = new List<string>();

            string[] dataToCollect = new string[] 
            { 
            "Doctor ID",
            "Doctor firstName",
            "Doctor lastName",
            "Hospital Name where doctor work"
            };

            try
            {
                foreach (var dataQuery in dataToCollect)
                {
                    Console.WriteLine($"Please provide {dataQuery} :");
                    newDoctorData.Add(Console.ReadLine());
                }

                var newDoctor = new Doctor(newDoctorData);
                dataProvider.AddDoctor(newDoctor);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void RemoveDoctor()
        {
            var dataProvider = new DoctorDataAccess();

            Console.WriteLine("Please provide ID of hospital to remove");
            string providedData = Console.ReadLine();
            int DoctorID = Int32.Parse(providedData);
            try
            {
                IEnumerable<Doctor> doctors = dataProvider.GetDoctors();
                Doctor doctorToDelete = doctors.Single(item => item.DoctorID == DoctorID);
                dataProvider.RemoveDoctor(doctorToDelete);
                Console.WriteLine("Successfully removed doctor");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void GetHospitals()
        {
            var dataProvider = new HospitalsDataProvider();
            var hospitals = dataProvider.GetHospitals();

            var showProvider = new ShowProvider();
            showProvider.PrintHospitals(hospitals);
        }

        private void AddHospital()
        {
            var dataProvider = new HospitalsDataProvider();

            List<string> newHospitalData = new List<string>() { };
            string[] dataToCollect = new string[] 
            {
                "Hospital ID",
                "Online Prescriptions availability : Yes/No",
                "Hospital Adress",
                "Hospital Opening Time",
                "Hospital Closing time"
            };

            // TODO: add defensive programming validation
            try
            {
                foreach (var dataQuery in dataToCollect)
                {
                    Console.WriteLine($"Please provide {dataQuery} :");
                    newHospitalData.Add(Console.ReadLine());
                }

                var hospital = new Hospital(newHospitalData);

                dataProvider.AddHospital(hospital);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private void RemoveHospital()
        {
            var dataProvider = new HospitalsDataProvider();

            Console.WriteLine("Please provide ID of hospital to remove");
            string providedData = Console.ReadLine();
            int hospitalID = Int32.Parse(providedData);
            try
            {
                IEnumerable<Hospital> hospitals = dataProvider.GetHospitals();
                Hospital hospitalToDelete = hospitals.Single(item => item.HospitalID == hospitalID);
                dataProvider.RemoveHospital(hospitalToDelete);
                Console.WriteLine("Successfully removed hospital");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
