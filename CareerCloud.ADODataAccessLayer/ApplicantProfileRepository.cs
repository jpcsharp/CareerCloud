using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CareerCloud.ADODataAccessLayer
{

    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {
        public readonly string connectionstring;
        private SqlConnection conn;
        public ApplicantProfileRepository()
        {
            connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
            conn = new SqlConnection(connectionstring);
        }
        public void Add(params ApplicantProfilePoco[] items)
        {
            // throw new NotImplementedException();
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into Applicant_Profiles (Id,Login,Currency,Current_Salary,Current_Rate,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)"
                + "values(@Id,@Login,@Currency,@Current_Salary,@Current_Rate,@Country_Code,@State_Province_Code,@Street_Address,@City_Town,@Zip_Postal_Code)";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Currency", item.Currency);
                cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                cmd.Parameters.AddWithValue("@City_Town", item.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Applicant_Profiles", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            var ae = new List<ApplicantProfilePoco>();
            while (dr.Read())
            {
                ae.Add(new ApplicantProfilePoco()
                {
                    Id = (Guid)dr["Id"],
                    Login = (Guid)dr["Login"],
                    CurrentSalary = Convert.IsDBNull(dr["Current_Salary"])?null:(decimal)dr["Current_Salary"],
                    CurrentRate = Convert.IsDBNull(dr["Current_Rate"])?null:(decimal)dr["Current_Rate"],
                    Currency = Convert.IsDBNull(dr["Currency"])?null:(string)dr["Currency"],
                    Country = Convert.IsDBNull(dr["Country_Code"])?null:(string)dr["Country_Code"],
                    Province = Convert.IsDBNull(dr["State_Province_Code"])?null:(string)dr["State_Province_Code"],
                    Street = Convert.IsDBNull(dr["Street_Address"])?null:(string)dr["Street_Address"],
                    City = Convert.IsDBNull(dr["City_Town"])?null:(string)dr["City_Town"],
                    PostalCode = Convert.IsDBNull(dr["Zip_Postal_Code"])?null:(string)dr["Zip_Postal_Code"]
                }
                    );
            }
            conn.Close();
            return ae;
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Delete from Applicant_Profiles where Id = @Id";
                cmd.Parameters.AddWithValue("@Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            foreach (var item in items)
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Update Applicant_Profiles set Login = @Login,Currency=@Currency,Current_Salary=@Current_Salary,Current_Rate=@Current_Rate,Country_Code=@Country_Code,State_Province_Code=@State_Province_Code,Street_Address=@Street_Address,City_Town=@City_Town,Zip_Postal_Code=@Zip_Postal_Code where Id = @Id";

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Login", item.Login);
                cmd.Parameters.AddWithValue("@Currency", item.Currency);
                cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                cmd.Parameters.AddWithValue("@City_Town", item.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
