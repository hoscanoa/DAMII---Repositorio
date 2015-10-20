using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Servicio.Models
{
    public class MyDataContext:DbContext
    {
        public DbSet<Empleado> listaEmpelados { get; set; }
    }
}