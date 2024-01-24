using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
        public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
        {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            foreach (CompanyJobEducationPoco poco in pocos)
            {
                poco.Major = "AB";
                poco.Importance = 0;
            }
            base.Add(pocos);
        }

        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (poco.Major!=null && poco.Major.Length < 2)
                {
                    exceptions.Add(new ValidationException(200, $"Major for CompanyJobEducation {poco.Major} must be at least 2 characters"));
                }
                if (poco.Importance < decimal.Negate(0))
                {
                    exceptions.Add(new ValidationException(201, $"Importance for CompanyJobEducation {poco.Importance} cannot be less than 0"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }

}
