using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyLocationController : ControllerBase
    {
        private readonly CompanyLocationLogic _logic;
        private readonly List<CompanyLocationPoco> _companyLocationPocologic=new List<CompanyLocationPoco>();
        public CompanyLocationController()
        {
            _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>());
        }

        [HttpGet, Route("companyLocation/{companyLocationId}")]
        [ProducesResponseType(typeof(CompanyLocationPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetCompanyLocation(Guid companyLocationId)
        {
            try
            {
                var companyLocation = _logic.Get(companyLocationId);
                return companyLocation != null ? Ok(companyLocation) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
        {
            try
            {
                 _logic.Add(companyLocationPocos);
                 return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult PutCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
        {
            try
            {
                _logic.Update(companyLocationPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        public ActionResult DeleteCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
        {
            try
            {
                _logic.Delete(companyLocationPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
    }
}
