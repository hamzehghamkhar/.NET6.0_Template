namespace app.DataLayer.Interfaces
{
    public interface IEntityDataBaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
