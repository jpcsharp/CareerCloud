using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyJobController : ControllerBase
    {
        private readonly CompanyJobLogic? _logic=new CompanyJobLogic(null);
        //private readonly List<CompanyJobPoco> _companyJobPocologic=new List<CompanyJobPoco>();
        public CompanyJobController()
        {
            _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
        }

        [HttpGet, Route("companyjob/{companyJobId}")]
        [ProducesResponseType(typeof(CompanyJobPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetCompanyJob(Guid companyJobId)
        {
            try
            {
                var companyjob = _logic.Get(companyJobId);
                return companyjob != null ? Ok(companyjob) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            try
            {
            _logic.Add(companyJobPocos);
             return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult PutCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            try
            {
                _logic.Update(companyJobPocos);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult DeleteCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            try
            {
                _logic.Delete(companyJobPocos);
                 return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
