﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalRegistrationApp.Views
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
