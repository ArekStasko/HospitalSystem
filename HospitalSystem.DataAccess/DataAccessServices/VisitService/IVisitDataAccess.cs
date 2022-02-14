using HospitalSystem.DataAccess.models;

namespace HospitalSystem.DataAccess.DataAccessServices
{
    public interface IVisitDataAccess
    {
        public IEnumerable<Visit> GetVisits();
        public void AddVisit(Visit visit);
        public void RemoveVisit(Visit visitToRemove);
        public void UpdateVisit(Visit visitToUpdate);
    }
}
