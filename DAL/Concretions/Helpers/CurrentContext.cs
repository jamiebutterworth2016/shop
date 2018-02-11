using DAL.Abstractions.Helpers;
using Effort;
using System;

namespace DAL.Concretions.Helpers
{
    public class CurrentContext : ICurrentContext, IDisposable
    {
        public Context Context { get; private set; }

        public void Create()
        {
            Context = new Context();
        }

        public void CreateTransient()
        {
            Context = new Context(DbConnectionFactory.CreateTransient());
        }

        public void Dispose()
        {
            if (Context != null) Context.Dispose();
        }
    }
}