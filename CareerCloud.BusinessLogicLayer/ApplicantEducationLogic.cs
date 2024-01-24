using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
        public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
        {
        private const int saltLengthLimit = 10;
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantEducationPoco poco in pocos)
            {
                DateTime sdate = poco.StartDate ?? DateTime.MinValue;
                DateTime cdate = poco.CompletionDate ?? DateTime.MinValue;
                poco.Applicant =poco.Applicant;
                poco.Major = poco.Major;
                poco.CertificateDiploma = poco.CertificateDiploma;
                if (cdate < sdate)
                {
                    poco.StartDate = Convert.IsDBNull(poco.StartDate) ? null : (DateTime)poco.StartDate;
                    poco.CompletionDate = Convert.IsDBNull(poco.CompletionDate) ? null : (DateTime)poco.CompletionDate; ;
                }
                poco.CompletionPercent = poco.CompletionPercent;

            }
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            string[] requiredExtendedPasswordChars = new string[] { "$", "*", "#", "_", "@" };

            foreach (var poco in pocos)
            {
                DateTime sdate = poco.StartDate ?? DateTime.MinValue;
                DateTime cdate = poco.CompletionDate ?? DateTime.MinValue;

                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Major} Cannot be empty or less than 3 characters"));
                }
                else if (poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Major} Cannot be empty or less than 3 characters"));
                }

                if (poco.StartDate>DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, $"StartDate for SecurityLogin {poco.StartDate} Cannot be greater than today"));
                }
                
                if (poco.CompletionDate < poco.StartDate)
                {
                    exceptions.Add(new ValidationException(109, $"CompletionDate for SecurityLogin {poco.CompletionDate} CompletionDate cannot be earlier than StartDate"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }

}
