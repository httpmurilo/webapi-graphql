using System;
using ApiGraph.Entities;

namespace ApiGraph.DomainObjects
{
    public interface IRepository<T> : IDisposable where T : Entity 
    {
        IUnitOfWork UnitOfWork { get; } 
    }
}