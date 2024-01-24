using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyJobSkillController : Controller
    {
        private readonly CompanyJobSkillLogic _logic;
        private readonly List<CompanyJobSkillPoco> _companyJobSkillPocologic=new List<CompanyJobSkillPoco>();
        public CompanyJobSkillController()
        {
            _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>());
        }

        [HttpGet, Route("companyJobSkill/{companyJobSkillId}")]
        [ProducesResponseType(typeof(CompanyJobSkillPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetCompanyJobSkill(Guid companyJobSkillId)
        {
            try
            {
                var companyJobSkill = _logic.Get(companyJobSkillId);
                return companyJobSkill != null ? Ok(companyJobSkill) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostCompanyJobSkill(CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            try
            {
                _logic.Add(companyJobSkillPocos); 
                return Ok();
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        public ActionResult PutCompanyJobSkill(CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            try
            {
                _logic.Update(companyJobSkillPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        public ActionResult DeleteCompanyJobSkill(CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            try
            {
                _logic.Delete(companyJobSkillPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
    }
}
