using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        private const int saltLengthLimit = 10;

        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        {
        }

        //public bool Authenticate(string userName, string password)
        //{
        //    CompanyLocationPoco poco = base.GetAll().Where(s => s.Login == userName).FirstOrDefault();
        //    if (null == poco)
        //    {
        //        return false;
        //    }
        //    return VerifyHash(password, poco.Password);
        //}

        public void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            foreach (CompanyLocationPoco poco in pocos)
            {
                poco.CountryCode = poco.CountryCode;
                poco.Province =poco.Province;
                poco.Street = poco.Street;
                poco.City = poco.City;
                poco.PostalCode =poco.PostalCode;
            }
            base.Add(pocos);
        }

        public void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)

            {
                if (string.IsNullOrEmpty(poco.CountryCode))
                {
                    exceptions.Add(new ValidationException(500, $"CountryCode for CompanyLocation {poco.CountryCode} cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Province))
                {
                    exceptions.Add(new ValidationException(501, $"Province for CompanyLocation {poco.Province} cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Street))
                {
                    exceptions.Add(new ValidationException(502, $"Street for CompanyLocation {poco.Street} cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.City))
                {
                    exceptions.Add(new ValidationException(503, $"City for CompanyLocation {poco.City} cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.PostalCode))
                {
                    exceptions.Add(new ValidationException(504, $"PostalCode for CompanyLocation {poco.PostalCode} cannot be empty"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
    }
}
