using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class ApplicantProfileController : ControllerBase
    {
        private readonly ApplicantProfileLogic _logic;
        //private readonly List<ApplicantProfilePoco> _applicantProfilePocologic = new List<ApplicantProfilePoco>();
        public ApplicantProfileController()
        {
            _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
        }
        [HttpGet,Route("profile/{applicantProfileid}")]
        [ProducesResponseType(typeof(ApplicantProfilePoco),200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetApplicantProfile(Guid applicantProfileid)
        {
            try
            {
                var profile = _logic.Get(applicantProfileid);
                return profile != null ? Ok(profile) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost, Route("profile/{applicantProfileid}")]
        [ProducesResponseType(typeof(ApplicantProfilePoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult PostApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
        {
            {
                try
                {
                    //foreach (var item in applicantProfilePocos)
                        _logic.Add(applicantProfilePocos);
                         return Ok();
                }
                catch (Exception ex)
                { return BadRequest(ex.Message); }
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApplicantProfilePoco), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantWorkHistory(ApplicantProfilePoco[] applicantProfilePocos)
        {
            try
            {
                //foreach (var item in applicantProfilePocos)
                    _logic.Update(applicantProfilePocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        [HttpPut]
        [ProducesResponseType(typeof(ApplicantProfilePoco), 200)]
        [ProducesResponseType(404)]
        public ActionResult PutApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
        {
            try
            {
                //foreach (var item in applicantProfilePocos)
                    _logic.Update(applicantProfilePocos);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ApplicantProfilePoco), 200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
        {
            try
            {
                foreach (var item in applicantProfilePocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _logic.Delete(applicantProfilePocos);
                    }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
