using Acer_Test.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Acer_Test.Repository
{
    public class EmployeeRepository
    {
        public SqlConnection con;
       
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["AcERT"].ToString();
            con = new SqlConnection(constr);

        }

        public IEnumerable<Employee> Emp_getlist(string eid)
        {
            connection();
            con.Open();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@EMp_id", eid);
            const string SP = "Employee_GetList";
           var data=  con.Query<Employee>(SP, dp, commandTimeout: 1800, commandType: CommandType.StoredProcedure);
            con.Close();

            return (data);

        }


        public int Emp_Insert(Employee emp)
        {
            connection();
            con.Open();

            //(NAME,MOBILE_NO,EMAIL_ID,DOB,PAN,CITY
            DynamicParameters dp = new DynamicParameters();
            const string sp2 = "Employee_insert";
            dp.Add("Emp_id", emp.Emp_Id);
            dp.Add("NAME", emp.NAME);
            dp.Add("MOBILE_NO", emp.MOBILE_NO);
            dp.Add("EMAIL_ID", emp.EMAIL_ID);
            dp.Add("DOB", emp.DOB);
            dp.Add("PAN", emp.PAN);
            dp.Add("STATE", emp.state);
            dp.Add("CITY", emp.CITY);
            dp.Add("RESUlT", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //con.Query<Employee>(SP, dp, commandTimeout: 1800, commandType: CommandType.StoredProcedure);
            con.Query<Int32>(sp2, dp, commandTimeout: 600, commandType: CommandType.StoredProcedure);
            var rtn=dp.Get<Int32>("RESUlT");
            //con.Close();
            return rtn;

        }

        //Emp_update
        public int Emp_update(Employee emp)
        {
            connection();
            con.Open();

            //(NAME,MOBILE_NO,EMAIL_ID,DOB,PAN,CITY
            DynamicParameters dp = new DynamicParameters();
            const string sp2 = "Employee_Update";
            dp.Add("Emp_id", emp.Emp_Id);
            dp.Add("NAME", emp.NAME);
            dp.Add("MOBILE_NO", emp.MOBILE_NO);
            dp.Add("EMAIL_ID", emp.EMAIL_ID);
            dp.Add("DOB", emp.DOB);
            dp.Add("PAN", emp.PAN);
            dp.Add("CITY", emp.CITY);
            dp.Add("RESUlT", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //con.Query<Employee>(SP, dp, commandTimeout: 1800, commandType: CommandType.StoredProcedure);
            con.Query<Int32>(sp2, dp, commandTimeout: 600, commandType: CommandType.StoredProcedure);
            var rtn = dp.Get<Int32>("RESUlT");
            //con.Close();
            return rtn;

        }

        
       public int Emp_Delete(Employee emp)
        {
            connection();
            con.Open();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@EMp_id", emp.Emp_Id);
            dp.Add("RESUlT", dbType: DbType.Int32, direction: ParameterDirection.Output);
            const string sp3 = "Employee_Delete";
            con.Query<Int32>(sp3, dp, commandTimeout: 600, commandType: CommandType.StoredProcedure);
            var rtn = dp.Get<Int32>("RESUlT");
            con.Close();
            return rtn;

        }

        public IEnumerable<City> Get_City(string state)
        {

            connection();
            con.Open();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@state", state);
            const string SP = "cITY_GetList";
            var data = con.Query<City>(SP, dp, commandTimeout: 1800, commandType: CommandType.StoredProcedure);
            con.Close();

            return data;

        }

    }
}

