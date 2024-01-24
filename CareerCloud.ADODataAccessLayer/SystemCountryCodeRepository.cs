using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public SystemCountryCodeRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params SystemCountryCodePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into System_Country_Codes (Code,Name)"
                + "values(@Code,@Name)";

                cmd.Parameters.AddWithValue("@Code", item.Code);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from System_Country_Codes", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<SystemCountryCodePoco>();
            while (dr.Read())
            {
                ae.Add(new SystemCountryCodePoco()
                {
                    //Id = dr["Id"],
                    Code = (string)dr["Code"],
                    Name = (string)dr["Name"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {

            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from System_Country_Codes where Code = @Code";
                cmd.Parameters.AddWithValue("@Code", item.Code);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update System_Country_Codes set Name = @Name where Code = @Code";

                cmd.Parameters.AddWithValue("@Code", item.Code);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
    }
}
