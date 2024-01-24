using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly ApplicantSkillLogic _logic;
        private readonly List<ApplicantSkillPoco> _applicantSkillPocologic=new List<ApplicantSkillPoco>();
        public ApplicantSkillController()
        {
            _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>());
        }
        [HttpGet, Route("skill/{applicantSkillId}")]
        [ProducesResponseType(typeof(ApplicantSkillPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetApplicantSkill(Guid applicantSkillId)
        {
            try
            {
                var skill = _logic.Get(applicantSkillId);
                return skill != null ? Ok(skill) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostApplicantSkill(ApplicantSkillPoco[] applicantSkillPocos)
        {
            try
            {
                foreach (var item in applicantSkillPocos)
                    _applicantSkillPocologic.Add(item);

                //foreach (var item in applicantSkillPocos)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutApplicantSkill(ApplicantSkillPoco[] applicantSkillPocos)
        {
            try
            {
                foreach (var item in applicantSkillPocos)
                    _applicantSkillPocologic.FirstOrDefault(p => p.Id == item.Id);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteApplicantSkill(ApplicantSkillPoco[] applicantSkillPocos)
        {
            try
            {
                foreach (var item in applicantSkillPocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _applicantSkillPocologic.Remove(_applicantSkillPocologic.FirstOrDefault(p => p.Id == item.Id));
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
