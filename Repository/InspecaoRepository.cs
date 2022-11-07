using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class InspecaoRepository : AbstractRepository<Inspecao>, IInspecaoRepository
    {
        public InspecaoRepository(ApplicationDbContext context) : base(context) { }


    }
}