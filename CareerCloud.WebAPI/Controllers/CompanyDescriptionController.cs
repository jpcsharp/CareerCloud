using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;
        private readonly List<CompanyDescriptionPoco> _companyDescriptionPocologic=new List<CompanyDescriptionPoco>();
        public CompanyDescriptionController()
        {
            _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
        }

        [HttpGet, Route("companydescription/{companyDescriptionId}")]
        [ProducesResponseType(typeof(CompanyDescriptionPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetCompanyDescription(Guid companyDescriptionId)
        {
            try
            {
                var companydescription = _logic.Get(companyDescriptionId);
                return companydescription != null ? Ok(companydescription) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            try
            {
                    _logic.Add(companyDescriptionPocos);
                  return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PutCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            try
            {
                _logic.Update(companyDescriptionPocos);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        public ActionResult DeleteCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            try
            {
                _logic.Delete(companyDescriptionPocos);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
