using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicio.Controllers
{
    public class EmpleadoController : ApiController
    {
        MyDataContext db = new MyDataContext();
        // GET api/empleado
        public IEnumerable<Empleado> Get()
        {
            return db.listaEmpelados.ToList();
        }

        // GET api/empleado/5
        public Empleado Get(string DNI)
        {
            return db.listaEmpelados.Where(x=>x.DNI.Equals(DNI)).SingleOrDefault();
        }

        // POST api/empleado
        public void Post(Empleado empleado)
        {
            db.listaEmpelados.Add(empleado);
            db.SaveChanges();
        }

        // PUT api/empleado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/empleado/5
        public void Delete(int id)
        {
        }
    }
}
