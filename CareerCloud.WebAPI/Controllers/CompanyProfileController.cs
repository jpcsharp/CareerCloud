using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyProfileController : Controller
    {
        private readonly CompanyProfileLogic? _logic=new CompanyProfileLogic(null);
        //private readonly List<CompanyProfilePoco> _companyProfilePocologic=new List<CompanyProfilePoco>();
        public CompanyProfileController()
        {
            _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>());
        }

        [HttpGet, Route("companyProfile/{companyProfileId}")]
        [ProducesResponseType(typeof(CompanyProfilePoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetCompanyProfile(Guid companyProfileId)
        {
            try
            {
                var companyProfile = _logic.Get(companyProfileId);
                if (companyProfile == null)
                {
                    return NotFound();
                }
                return Ok(companyProfile);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(CompanyProfilePoco), 200)]
        [ProducesResponseType(404)]
        public ActionResult PostCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            try
            {
                  _logic.Add(companyProfilePocos);

                //foreach (var item in companyProfilePocos)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult PutCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            try
            {
                //foreach (var item in companyProfilePocos)
                    _logic.Update(companyProfilePocos);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            try
            {
                 _logic.Delete(companyProfilePocos);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }
    }
}
