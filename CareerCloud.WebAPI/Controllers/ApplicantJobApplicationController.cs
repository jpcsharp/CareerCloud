using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class ApplicantJobApplicationController : ControllerBase
    {   
        private readonly ApplicantJobApplicationLogic _logic;
        private readonly List<ApplicantJobApplicationPoco> _applicantJobApplicationPocologic=new List<ApplicantJobApplicationPoco>();
        public ApplicantJobApplicationController()
        {
            _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>());
        }

        [HttpGet, Route("jobapplication/{applicantJobApplicationId}")]
        [ProducesResponseType(typeof(ApplicantJobApplicationPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
        {
            try
            {
                var jobapplication = _logic.Get(applicantJobApplicationId);
                return jobapplication != null ? Ok(jobapplication) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            try
            {
                foreach (var item in applicantJobApplicationPocos)
                    _applicantJobApplicationPocologic.Add(item);

                //foreach (var item in applicantWorkHistoryPoco)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            try
            {
                foreach (var item in applicantJobApplicationPocos)
                    _applicantJobApplicationPocologic.FirstOrDefault(p => p.Id == item.Id);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            try
            {
                foreach (var item in applicantJobApplicationPocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _applicantJobApplicationPocologic.Remove(_applicantJobApplicationPocologic.FirstOrDefault(p => p.Id == item.Id));
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
