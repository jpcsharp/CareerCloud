using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private readonly CompanyJobDescriptionLogic? _logic=new CompanyJobDescriptionLogic(null);
       // private readonly List<CompanyJobDescriptionPoco> _companyJobDescriptionPocologic = new List<CompanyJobDescriptionPoco>();

        public CompanyJobsDescriptionController()
        {
            _logic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>());
        }

        [HttpGet, Route("companyJobDescription/{companyJobDescriptionId}")]
        [ProducesResponseType(typeof(CompanyJobDescriptionPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetCompanyJobsDescription(Guid companyJobDescriptionId)
        {
            try
            {
                var companyJobDescription = _logic.Get(companyJobDescriptionId);
                return Ok(companyJobDescription);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            try
            {
                  _logic.Add(companyJobDescriptionPocos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult PutCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            try
            {
                 _logic.Update(companyJobDescriptionPocos);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult DeleteCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            try
            {
                _logic.Delete(companyJobDescriptionPocos);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
