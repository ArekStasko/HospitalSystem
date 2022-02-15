
namespace HospitalSystem.DataAccess.models
{
    public interface IVisit
    {
        public int VisitID { get; }
        public int HospitalID { get; }
        public bool Available { get; set; }
        public string Time { get; }
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public string[] MainInfoToDataRow();
        public string[] AllInfoToDataRow();
    }
}
