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
    public class CompanyJobDescriptionRepository : IDataRepository<CompanyJobDescriptionPoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public CompanyJobDescriptionRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Company_Jobs_Descriptions (Id,Job,Job_Name,Job_Descriptions)"
                + "values(@Id,@Job,@Job_Name,@Job_Descriptions)";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Company_Jobs_Descriptions", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<CompanyJobDescriptionPoco>();
            while (dr.Read())
            {
                ae.Add(new CompanyJobDescriptionPoco()
                {
                    Id = (Guid)dr["Id"],
                    Job = (Guid)dr["Job"],
                    JobName = (string)dr["Job_Name"],
                    JobDescriptions = (string)dr["Job_Descriptions"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {

            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from Company_Jobs_Descriptions where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update Company_Jobs_Descriptions set Job=@Job,Job_Name = @Job_Name,Job_Descriptions=@Job_Descriptions where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Job", item.Job);
                cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
