using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class SystemLanguageCodeController : Controller
    {
        private readonly SystemLanguageCodeLogic _logic;
        private readonly List<SystemLanguageCodePoco> _systemLanguageCodePocologic=new List<SystemLanguageCodePoco>();
        public SystemLanguageCodeController()
        {
            _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>());
        }

        [HttpGet, Route("systemLangCodeLanguage/{systemLangCodeLanguageId}")]
        [ProducesResponseType(typeof(SystemLanguageCodePoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetSystemLanguageCode(string languageId)
        {
           var tr= _systemLanguageCodePocologic.FirstOrDefault(p => p.LanguageID == languageId);
            return Ok();
        }

        public ActionResult PostSystemLanguageCode(SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            try
            {
                foreach (var item in systemLanguageCodePocos)
                    _systemLanguageCodePocologic.Add(item);

                //foreach (var item in systemLanguageCodePocos)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutSystemLanguageCode(SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            try
            {
                foreach (var item in systemLanguageCodePocos)
                    _systemLanguageCodePocologic.FirstOrDefault(p => p.LanguageID == item.LanguageID);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteSystemLanguageCode(SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            try
            {
                foreach (var item in systemLanguageCodePocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _systemLanguageCodePocologic.Remove(_systemLanguageCodePocologic.FirstOrDefault(p => p.LanguageID == item.LanguageID));
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
