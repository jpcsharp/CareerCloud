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
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public SecurityLoginRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params SecurityLoginPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Security_Logins (Id,Login,Password,Created_Date," +
                    "Password_Update_Date,Agreement_Accepted_Date,Is_Locked,Is_Inactive," +
                    "Email_Address,Phone_Number,Full_Name,Force_Change_Password,Prefferred_Language)"
                + "values(@Id,@Login,@Password,@Created_Date,@Password_Update_Date,@Agreement_Accepted_Date," +
                "@Is_Locked,@Is_Inactive,@Email_Address,@Phone_Number,@Full_Name,@Force_Change_Password,@Prefferred_Language)";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Password", item.Password);
                cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Security_Logins", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<SecurityLoginPoco>();
            while (dr.Read())
            {
                ae.Add(new SecurityLoginPoco()
                {
                    Id =(Guid) dr["Id"],
                    Login = (string)dr["Login"],
                    Password = (string)dr["Password"],
                    Created = (DateTime)dr["Created_Date"],
                    PasswordUpdate = Convert.IsDBNull(dr["Password_Update_Date"]) ? null : (DateTime)dr["Password_Update_Date"],
                    AgreementAccepted = Convert.IsDBNull(dr["Agreement_Accepted_Date"]) ? null : (DateTime)dr["Agreement_Accepted_Date"],
                    IsLocked = (bool)dr["Is_Locked"],
                    IsInactive = (bool)dr["Is_Inactive"],
                    EmailAddress = (string)dr["Email_Address"],
                    PhoneNumber = Convert.IsDBNull(dr["Phone_Number"]) ? null : (string)dr["Phone_Number"],
                    FullName = Convert.IsDBNull(dr["Full_Name"]) ? null : (string)dr["Full_Name"],
                    ForceChangePassword = (bool)dr["Force_Change_Password"],
                    PrefferredLanguage = Convert.IsDBNull(dr["Prefferred_Language"]) ? null : (string)dr["Prefferred_Language"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {

            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from Security_Logins where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update Security_Logins set Login = @Login,Password=@Password,Created_Date=@Created_Date," +
                    "Password_Update_Date=@Password_Update_Date,Agreement_Accepted_Date=@Agreement_Accepted_Date," +
                    "Is_Locked=@Is_Locked,Is_Inactive=@Is_Inactive," +
                    "Email_Address=@Email_Address,Phone_Number=@Phone_Number,Full_Name=@Full_Name," +
                    "Force_Change_Password=@Force_Change_Password,Prefferred_Language=@Prefferred_Language where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Password", item.Password);
                cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
