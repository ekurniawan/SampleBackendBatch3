using MyBackendBatch3.DAL;
using MyBackendBatch3.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBackendBatch3.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeDAL _empDAL;
        public EmployeeController()
        {
            _empDAL = new EmployeeDAL();
        }

        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            var results = _empDAL.GetAll();
            return results;
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public IHttpActionResult Post(Employee emp)
        {
            try
            {
                _empDAL.Insert(emp);
                return Ok($"Data Emp {emp.EmpName} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Employee/5
        public IHttpActionResult Put(Employee emp)
        {
            try
            {
                _empDAL.Update(emp);
                return Ok($"Data Emp {emp.EmpName} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Employee/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _empDAL.Delete(id);
                return Ok("Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
