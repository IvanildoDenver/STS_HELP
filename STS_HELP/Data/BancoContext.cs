using Microsoft.EntityFrameworkCore;
using STS_HELP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STS_HELP.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<ChamadosModel> Chamados { get; set; }

    }
}
