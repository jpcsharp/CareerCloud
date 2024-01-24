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
    public class ApplicantWorkHistoryRepository : IDataRepository<ApplicantWorkHistoryPoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public ApplicantWorkHistoryRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Applicant_Work_History (Id,Applicant,Company_Name,Country_Code,Location,Job_Title,Job_Description,Start_Month,Start_Year,End_Month,End_Year)"
                + "values(@Id,@Applicant,@Company_Name,@Country_Code,@Location,@Job_Title,@Job_Description,@Start_Month,@Start_Year,@End_Month,@End_Year)";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                cmd.Parameters.AddWithValue("@Location", item.Location);
                cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Applicant_Work_History", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<ApplicantWorkHistoryPoco>();
            while (dr.Read())
            {
                ae.Add(new ApplicantWorkHistoryPoco()
                {
                    Id =(Guid) dr["Id"],
                    Applicant = (Guid)dr["Applicant"],
                    CompanyName = (string)dr["Company_Name"],
                    CountryCode = (string)dr["Country_Code"],
                    Location = (string)dr["Location"],
                    JobTitle = (string)dr["Job_Title"],
                    JobDescription = (string)dr["Job_Description"],
                    StartMonth = (Int16)dr["Start_Month"],
                    StartYear = (int)dr["Start_Year"],
                    EndMonth = (Int16)dr["End_Month"],
                    EndYear = (int)dr["End_Year"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from Applicant_Work_History where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update Applicant_Work_History set Applicant = @Applicant," +
                    "Company_Name=@Company_Name,Country_Code=@Country_Code," +
                    "Location=@Location,Job_Title=@Job_Title,Job_Description=@Job_Description," +
                    "Start_Month=@Start_Month,Start_Year=@Start_Year," +
                    "End_Month=@End_Month,End_Year=@End_Year where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                cmd.Parameters.AddWithValue("@Location", item.Location);
                cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
