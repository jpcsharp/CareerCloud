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
    public class SystemLanguageCodeLogic
    {
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
        {
        }

        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            foreach (SystemLanguageCodePoco poco in pocos)
            {
                poco.LanguageID = Convert.IsDBNull(poco.LanguageID) ? null : poco.LanguageID;
                poco.Name = Convert.IsDBNull(poco.Name) ? null : poco.Name;
                poco.NativeName = Convert.IsDBNull(poco.NativeName) ? null : poco.NativeName;
            }
            Add(pocos);
        }

        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            Update(pocos);
        }

        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            string[] requiredExtendedPasswordChars = new string[] { "$", "*", "#", "_", "@" };

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, $"LanguageID for SystemLanguageCode {poco.LanguageID} cannot be null"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001, $"Name for SystemLanguageCode {poco.Name} cannot be null"));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, $"NativeName for SystemLanguageCode {poco.NativeName} cannot be null"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            Delete(pocos);
        }
        public void GetAll(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            GetAll(pocos);
        }

        public void Get(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            Get(pocos);
        }


    }

}
