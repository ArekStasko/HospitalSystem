using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalRegistrationApp.DataAccess.models
{
    public abstract class AbstractModel
    {
        public abstract string[] ConvertToDataRow();
    }
}


