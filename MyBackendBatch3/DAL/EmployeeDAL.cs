using MyBackendBatch3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MyBackendBatch3.DAL
{
    public class EmployeeDAL
    {
        private string GetConnStr()
        {
            return WebConfigurationManager
                .ConnectionStrings["MyConnString"].ConnectionString;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees order by EmpName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstEmployee.Add(new Employee
                        {
                            EmpId = Convert.ToInt32(dr["EmpId"]),
                            EmpName = dr["EmpName"].ToString(),
                            Designation = dr["Designation"].ToString(),
                            Department = dr["Department"].ToString(),
                            Qualification = dr["Qualification"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstEmployee;
        }
    }
}