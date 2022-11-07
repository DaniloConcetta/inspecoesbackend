using System;
using System.Threading.Tasks;
using Inspecoes.Data;
using Inspecoes.Interfaces;
using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Repository
{
    public class StatusInspecaoRepository : AbstractRepository<StatusInspecao>, IStatusInspecaoRepository
    {
        public StatusInspecaoRepository(ApplicationDbContext context) : base(context) { }
    }
}