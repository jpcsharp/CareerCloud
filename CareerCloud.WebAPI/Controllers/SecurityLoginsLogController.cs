using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class SecurityLoginsLogController : Controller
    {
        private readonly SecurityLoginsLogLogic _logic;
        private readonly List<SecurityLoginsLogPoco> _securityLoginsLogPocologic=new List<SecurityLoginsLogPoco>();
        public SecurityLoginsLogController()
        {
            _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>());
        }

        [HttpGet, Route("securityLoginsLog/{securityLoginLogId}")]
        [ProducesResponseType(typeof(SecurityLoginsLogPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetSecurityLoginLog(Guid securityLoginLogId)
        {
            try
            {
                var securityLoginsLog = _logic.Get(securityLoginLogId);
                return securityLoginsLog != null ? Ok(securityLoginsLog) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            try
            {
                 _logic.Add(securityLoginsLogPocos);
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public ActionResult PutSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            try
            {
                _logic.Update(securityLoginsLogPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        public ActionResult DeleteSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            try
            {
                _logic.Delete(securityLoginsLogPocos);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
