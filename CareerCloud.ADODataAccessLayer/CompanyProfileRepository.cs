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
    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public CompanyProfileRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params CompanyProfilePoco[] items)
        {
            
             foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Company_Profiles (Id,Registration_Date,Company_Website,Contact_Phone,Contact_Name,Company_Logo)"
                + "values(@Id,@Registration_Date,@Company_Website,@Contact_Phone,@Contact_Name,@Company_Logo)";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Company_Profiles", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<CompanyProfilePoco>();
            while (dr.Read())
            {
                ae.Add(new CompanyProfilePoco()
                {
                    Id = (Guid)dr["Id"],
                    RegistrationDate = (DateTime)dr["Registration_Date"],
                    CompanyWebsite = Convert.IsDBNull(dr["Company_Website"]) ? null : (string)dr["Company_Website"],
                    ContactPhone = (string)dr["Contact_Phone"],
                    ContactName = Convert.IsDBNull(dr["Contact_Name"]) ? null : (string)dr["Contact_Name"],
                    CompanyLogo = Convert.IsDBNull(dr["Company_Logo"]) ? null : (byte[])dr["Company_Logo"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from Company_Profiles where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update Company_Profiles set Registration_Date = @Registration_Date,Company_Website=@Company_Website,Contact_Phone=@Contact_Phone,Contact_Name=@Contact_Name,Company_Logo=@Company_Logo where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
