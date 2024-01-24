using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic
    {
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        {
        }

        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            foreach (SystemCountryCodePoco poco in pocos)
            {
                poco.Code = poco.Code;
                poco.Name = poco.Name;
            }
            Add(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            Update(pocos);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, $"Code for SystemCountryCode {poco.Code} cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, $"Name for SystemCountryCode {poco.Name} cannot be empty"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            Delete(pocos);
        }
        public void GetAll(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            GetAll(pocos);
        }

        public void Get(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            Get(pocos);
        }
        public void Get(string code)
        {
            //Verify(pocos);
            Get(code);
        }

    }

}
