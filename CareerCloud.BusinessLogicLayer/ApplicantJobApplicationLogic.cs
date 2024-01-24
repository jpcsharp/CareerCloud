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
        public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
        {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantJobApplicationPoco poco in pocos)
            {
                poco.ApplicationDate = DateTime.Now.ToUniversalTime();
            }
            base.Add(pocos);
        }

        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            var todaydate = DateTime.Now.ToUniversalTime();
            foreach (var poco in pocos)
            {
                if (poco.ApplicationDate> todaydate)
                {
                    exceptions.Add(new ValidationException(110, $"ApplicationDate for ApplicantJobApplication {poco.ApplicationDate} cannot be null"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }


    }

}
