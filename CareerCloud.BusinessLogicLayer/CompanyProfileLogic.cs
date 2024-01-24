using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
        public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
        {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            foreach (CompanyProfilePoco poco in pocos)
            {
                poco.CompanyWebsite = "www.something.edu";
                poco.ContactPhone = "416-234-2233";
            }
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            //var phoneformat=  Regex.Match(poco.ContactPhone, @"^(\+[0-9])$");

            foreach (var poco in pocos)
            {
                if (poco.CompanyWebsite == null)
                {
                    exceptions.Add(new ValidationException(102, $"CompanyWebsite for CompanyProfile {poco.CompanyWebsite} cannot be empty"));
                }
                else
                {
                    if (!(poco.CompanyWebsite.EndsWith(".ca") || poco.CompanyWebsite.EndsWith(".com") || poco.CompanyWebsite.EndsWith(".biz")))
                    {
                        exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfile {poco.CompanyWebsite} Valid websites must end with the following extensions – \".ca\", \".com\", \".biz\""));
                    }
                }

                if (poco.ContactPhone == null)
                {
                    exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} cannot be null"));
                }
                else
                {
                    //if (!(Regex.Match(poco.ContactPhone, @"^(\+[0-9]{9})$").Success))
                    if (!(Regex.Match(poco.ContactPhone, @"^\d{3}-\d{3}-\d{4}$").Success))
                    {
                        exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} Must correspond to a valid phone number (e.g. 416-555-1234)"));
                    }
                }
                    //@"^(\+[0-9]{9})$"
                }


            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }

}
