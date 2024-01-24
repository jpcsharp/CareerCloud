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
    public class SecurityLoginsLogRepository : IDataRepository<SecurityLoginsLogPoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public SecurityLoginsLogRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Security_Logins_Log (Id,Login,Source_IP,Logon_Date,Is_Succesful)"
                + "values(@Id,@Login,@Source_IP,@Logon_Date,@Is_Succesful)";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Security_Logins_Log", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<SecurityLoginsLogPoco>();
            while (dr.Read())
            {
                ae.Add(new SecurityLoginsLogPoco()
                {
                    Id = (Guid)dr["Id"],
                    Login = (Guid)dr["Login"],
                    SourceIP = (string)dr["Source_IP"],
                    LogonDate = (DateTime)dr["Logon_Date"],
                    IsSuccesful = (bool)dr["Is_Succesful"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {

            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from Security_Logins_Log where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update Security_Logins_Log set Login=@Login,Source_IP = @Source_IP,Logon_Date=@Logon_Date,Is_Succesful=@Is_Succesful where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
