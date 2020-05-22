using System;
using System.Threading.Tasks;

namespace ApiGraph.DomainObjects
{
    public interface IUnitOfWork 
    {
        Task<bool> Commit();
    } 
   
}