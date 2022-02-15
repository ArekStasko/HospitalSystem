using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public interface IVisitDataAccess
    {
        public IEnumerable<IVisit> GetVisits();
        public void AddVisit(IVisit visit);
        public void RemoveVisit(IVisit visitToRemove);
        public void UpdateVisit(IVisit visitToUpdate);
    }
}
