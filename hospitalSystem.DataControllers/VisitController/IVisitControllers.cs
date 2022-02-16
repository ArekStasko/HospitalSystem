using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataControllers.AdminControllers
{
    public interface IVisitControllers
    {
        public IEnumerable<IVisit> GetVisits();
        public void AddVisit();
        public void RemoveVisit();
        public void GetMyVisits();
        public void SignUpForVisit();

    }
}
