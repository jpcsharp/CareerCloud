using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
        public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
        {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantProfilePoco poco in pocos)
            {
                poco.CurrentSalary = poco.CurrentSalary;
                poco.CurrentRate = poco.CurrentRate;
                poco.Country = poco.Country;
                poco.City = poco.City;
            }
            base.Add(pocos);
           // CurrentSalary cannot be negative
            //CurrentRate cannot be negative

        }


        public override void Update(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (poco.CurrentSalary<decimal.Negate(0))
                {
                    exceptions.Add(new ValidationException(111, $"CurrentSalary for ApplicantProfile {poco.CurrentSalary} cannot be negative"));
                }
                if (poco.CurrentRate<decimal.Negate(0))
                {
                    exceptions.Add(new ValidationException(112, $"CurrentRate for ApplicantProfile {poco.CurrentRate} cannot be negative"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }

}
