using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WSTareas.Model.Context
{
    public class TareaContext: DbContext
    {
        public DbSet<Tarea> Tareas { get; set; }
        public TareaContext() : base("DEVELOPMENT_ConnectionString") { }
    }
}