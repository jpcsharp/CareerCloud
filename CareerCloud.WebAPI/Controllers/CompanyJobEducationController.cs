using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyJobEducationController : Controller
    {
        private readonly CompanyJobEducationLogic _logic;
        private readonly List<CompanyJobEducationPoco> _companyJobEducationPocologic=new List<CompanyJobEducationPoco>();
        public CompanyJobEducationController()
        {
            _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        }

        [HttpGet, Route("companyJobEducation/{companyJobEducationId}")]
        [ProducesResponseType(typeof(CompanyJobEducationPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetCompanyJobEducation(Guid companyJobEducationId)
        {
            try
            {
                var companyJobEducation = _logic.Get(companyJobEducationId);
                return companyJobEducation != null ? Ok(companyJobEducation) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            try
            {
                 _logic.Add(companyJobEducationPocos);
                    return Ok();
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        public ActionResult PutCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            try
            {
                _logic.Update(companyJobEducationPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        public ActionResult DeleteCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
        {
            try
            {
                _logic.Delete(companyJobEducationPocos);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
