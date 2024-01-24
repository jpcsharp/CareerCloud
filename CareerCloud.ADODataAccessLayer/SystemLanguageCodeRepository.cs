using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemLanguageCodeRepository : IDataRepository<SystemLanguageCodePoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public SystemLanguageCodeRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params SystemLanguageCodePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into System_Language_Codes (LanguageID,Name,Native_Name)"
                + "values(@LanguageID,@Name,@Native_Name)";

                cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from System_Language_Codes", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<SystemLanguageCodePoco>();
            while (dr.Read())
            {
                ae.Add(new SystemLanguageCodePoco()
                {
                    LanguageID = (string)dr["LanguageID"],
                    Name = (string)dr["Name"],
                    NativeName = (string)dr["Native_Name"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {

            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from System_Language_Codes where LanguageID = @LanguageID";
                cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update System_Language_Codes set Native_Name = @Native_Name,Name=@Name where LanguageID = @LanguageID";

                cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
    }
}
