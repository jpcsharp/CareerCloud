using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class ApplicantEducationController : ControllerBase
    {
        private readonly ApplicantEducationLogic _logic;
        private readonly List<ApplicantEducationPoco> _applicantEducationPocologic = new List<ApplicantEducationPoco>();
        public ApplicantEducationController()
        {
            //_logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>());
        }

        [HttpGet, Route("education/{applicantEducationid}")]
        [ProducesResponseType(typeof(ApplicantEducationPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetApplicantEducation(Guid applicantEducationid)
        {
            try
            {
                var education = _logic.Get(applicantEducationid);
                return education != null ? Ok(education) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        public ActionResult PostApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
        {
            try
            {
                foreach (var item in applicantEducationPocos)
                    _applicantEducationPocologic.Add(item);

                //foreach (var item in applicantEducationPocos)
                //    _logic.Add(applicantEducationPocos);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
        {
            try
            {
                foreach (var item in applicantEducationPocos)
                    _applicantEducationPocologic.FirstOrDefault(p => p.Id == item.Id);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
        {
            try
            {
                foreach (var item in applicantEducationPocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _applicantEducationPocologic.Remove(_applicantEducationPocologic.FirstOrDefault(p => p.Id == item.Id));
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


