using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/applicant/v1/systemcountrycode")]
    public class SystemCountryCodeController : Controller
    {
        private readonly SystemCountryCodeLogic? _logic = new SystemCountryCodeLogic(null);
        //private readonly List<SystemCountryCodePoco> _systemCountryCodePocologic=new List<SystemCountryCodePoco>();
        public SystemCountryCodeController()
        {
            _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>());
        }

        public ActionResult GetAll()
        {
            return Ok(_logic);
        }

        [HttpGet, Route("systemCountry/{systemCountryId}")]
        [ProducesResponseType(typeof(SystemCountryCodePoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetSystemCountryCode(string code)
        {

            _logic.Get(code);
            return Ok();
        }

        [HttpGet]
        [Route("countryCode/{systemCountryCodeId:string}")]
        [ProducesResponseType(typeof(SystemCountryCodePoco), 200)]
        [ProducesResponseType(404)]
        //public ActionResult GetSystemCountryCode(string systemCountryCodeId)
        //{
        //    var result= _logic.Get(systemCountryCodeId);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        public ActionResult PostSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            try
            {
                //foreach (var item in systemCountryCodePocos)
                  //  _systemCountryCodePocologic.Add(item);

                //foreach (var item in systemCountryCodePocos)
                   _logic.Add(systemCountryCodePocos);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            try
            {
                //foreach (var item in systemCountryCodePocos)
                    _logic.Update(systemCountryCodePocos);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            try
            {
                //foreach (var item in systemCountryCodePocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                        _logic.Delete(systemCountryCodePocos);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }

        //public ActionResult GetSystemCountryCode(string code)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
