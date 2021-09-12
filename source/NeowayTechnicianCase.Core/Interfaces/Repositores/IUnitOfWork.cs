namespace NeowayTechnicianCase.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}