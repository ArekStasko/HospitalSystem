
namespace HospitalSystem.DataAccess.models
{
    public interface IHospital
    {
        public int HospitalID { get; }
        public bool IsOnlinePrescriptions { get; }
        public string HospitalAdress { get; }
        public string HospitalOpeningTime { get; }
        public string HospitalClosingTime { get; }
        public string HospitalName { get; }
        public string[] ConvertToDataRow();
    }
}
