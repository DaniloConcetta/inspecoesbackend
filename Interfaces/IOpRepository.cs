using System;
using System.Threading.Tasks;
using Inspecoes.Models;

namespace Inspecoes.Interfaces
{
    public interface IOpRepository : IAbstractRepository<Op>
    {
        Task<Op> GetByCodigo(string Opnumero);
    }



}