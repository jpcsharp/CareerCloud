﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            foreach (CompanyDescriptionPoco poco in pocos)
            {
                poco.CompanyDescription = poco.CompanyDescription;
                poco.CompanyName = poco.CompanyName;
            }
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (poco.CompanyDescription == null)
                {
                    exceptions.Add(new ValidationException(106, $"CompanyDescription for ApplicantResume {poco.CompanyDescription} cannot be empty"));
                }
                if(poco.CompanyDescription.Length < 2)
                {
                        exceptions.Add(new ValidationException(106, $"CompanyDescription for ApplicantResume {poco.CompanyDescription} must be greater than 2 characters"));
                }
                if (poco.CompanyName == null)
                {
                    exceptions.Add(new ValidationException(107, $"CompanyName for ApplicantResume {poco.CompanyName} cannot be empty"));
                }
                if(poco.CompanyName.Length < 2)
                {
                    exceptions.Add(new ValidationException(107, $"CompanyName for ApplicantResume {poco.CompanyName} must be greater than 2 characters"));
                }

                //if (poco.CompanyName.Length < 2)
                //{
                //}
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }

}
