using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class ApplicantResumeController : Controller
    {
        private readonly ApplicantResumeLogic _logic;
        private readonly List<ApplicantResumePoco> _applicantResumePocologic=new List<ApplicantResumePoco>();
        public ApplicantResumeController()
        {
            _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>());
        }

        [HttpGet, Route("resume/{applicantResumeId}")]
        [ProducesResponseType(typeof(ApplicantResumePoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetApplicantResume(Guid applicantResumeId)
        {
            try
            {
                var resume = _logic.Get(applicantResumeId);
                return resume != null ? Ok(resume) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostApplicantResume(ApplicantResumePoco[] applicantResumePocos)
        {
            try
            {
                foreach (var item in applicantResumePocos)
                    _applicantResumePocologic.Add(item);

                //foreach (var item in applicantResumePocos)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult PutApplicantResume(ApplicantResumePoco[] applicantResumePocos)
        {
            try
            {
                foreach (var item in applicantResumePocos)
                    _applicantResumePocologic.FirstOrDefault(p => p.Id == item.Id);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteApplicantResume(ApplicantResumePoco[] applicantResumePocos)
        {
            try
            {
                foreach (var item in applicantResumePocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _applicantResumePocologic.Remove(_applicantResumePocologic.FirstOrDefault(p => p.Id == item.Id));
                    }
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
