namespace DAL.Abstractions.Helpers
{
    public interface ICurrentContext
    {
        Context Context { get; }

        void Create();
        void CreateTransient();
    }
}