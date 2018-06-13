using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Jacaranda.Entity;

namespace Jacaranda.Data
{
    public class JacarandaDbContext : DbContext
    {
        public JacarandaDbContext() : base("JacarandaDbContext")
        {
        }

        public DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
