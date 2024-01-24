using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class CompanyJobDescriptionController : Controller
    {
        private readonly CompanyJobDescriptionLogic _logic;
        private readonly List<CompanyJobDescriptionPoco> _companyJobDescriptionPocologic=new List<CompanyJobDescriptionPoco>();

        public CompanyJobDescriptionController()
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
                return companyJobDescription != null ? Ok(companyJobDescription) : NotFound();
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
                foreach (var item in companyJobDescriptionPocos)
                    _companyJobDescriptionPocologic.Add(item);

                //foreach (var item in companyJobDescriptionPocos)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutCompanyJobDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            try
            {
                foreach (var item in companyJobDescriptionPocos)
                    _companyJobDescriptionPocologic.FirstOrDefault(p => p.Id == item.Id);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteCompanyJobDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            try
            {
                foreach (var item in companyJobDescriptionPocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _companyJobDescriptionPocologic.Remove(_companyJobDescriptionPocologic.FirstOrDefault(p => p.Id == item.Id));
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
