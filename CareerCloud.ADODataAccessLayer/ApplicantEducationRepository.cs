using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public ApplicantEducationRepository()
        {
             connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params ApplicantEducationPoco[] items)
        {
            //throw new NotImplementedException();
            foreach(var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Applicant_Educations (Id,Applicant,Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent)"
                + "values(@Id,@Applicant,@Major,@Certificate_Diploma,@Start_Date,@Completion_Date,@Completion_Percent)";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Applicant_Educations", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<ApplicantEducationPoco>();
                while(dr.Read())
                {
                    ae.Add(new ApplicantEducationPoco()
                    {
                        Id = (Guid)dr["Id"],
                        Applicant =(Guid) dr["Applicant"],
                        Major = (string)dr["Major"],
                        CertificateDiploma = Convert.IsDBNull(dr["Certificate_Diploma"]) ? null : (string)dr["Certificate_Diploma"],
                        StartDate = Convert.IsDBNull(dr["Start_Date"]) ? null : (DateTime)dr["Start_Date"],
                        CompletionDate = Convert.IsDBNull(dr["Completion_Date"])? null : (DateTime)dr["Completion_Date"],
                        CompletionPercent = Convert.IsDBNull(dr["Completion_Percent"]) ? null : (byte)dr["Completion_Percent"]
                    }
                        );
                }
                conn.Close();
                return ae;
        }


        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from Applicant_Educations where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update Applicant_Educations set Applicant = @Applicant,Major=@Major,Certificate_Diploma=@Certificate_Diploma,Start_Date=@Start_Date,Completion_Date=@Completion_Date,Completion_Percent=@Completion_Percent where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                cmd.Parameters.AddWithValue("@Major", item.Major);
                cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
} 