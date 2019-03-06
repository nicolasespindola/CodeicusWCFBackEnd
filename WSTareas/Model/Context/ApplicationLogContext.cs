using System.Data.Entity;

namespace WSTareas.Model.Context
{
    public class ApplicationLogContext : DbContext
    {
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public ApplicationLogContext() : base("DEVELOPMENT_ConnectionString") { }
    }
}