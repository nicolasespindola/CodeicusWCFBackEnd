using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WSTareas.Model.Context
{
    public class ExceptionLogContext : DbContext
    {
        public DbSet<ExceptionLog> Exceptions { get; set; }
        public ExceptionLogContext() : base("DEVELOPMENT_ConnectionString") { }
    }
}