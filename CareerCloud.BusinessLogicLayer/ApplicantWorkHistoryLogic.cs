using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
        public class ApplicantWorkHistoryLogic : BaseLogic<ApplicantWorkHistoryPoco>
        {
        public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
        {
        }
        private const int saltLengthLimit = 2;

        public override void Add(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantWorkHistoryPoco poco in pocos)
            {
                poco.CompanyName ="A";
            }
            base.Add(pocos);
        }

        public override void Update(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected void Verify(ApplicantWorkHistoryPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if(poco.CompanyName == null)
                {
                    exceptions.Add(new ValidationException(101, $"CompanyName for ApplicantWorkHistory {poco.CompanyName} cannot be empty"));
                }
                else 
                {
                    exceptions.Add(new ValidationException(105, $"CompanyName for ApplicantWorkHistory {poco.CompanyName} Must be greater then 2 characters"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }

}
