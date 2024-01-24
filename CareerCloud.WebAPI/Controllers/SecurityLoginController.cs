using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;
        private readonly List<SecurityLoginPoco> _securityLoginPocologic=new List<SecurityLoginPoco>();
        public SecurityLoginController()
        {
            _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
        }

        [HttpGet, Route("securityLogin/{securityLoginId}")]
        [ProducesResponseType(typeof(SecurityLoginPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetSecurityLogin(Guid securityLoginId)
        {
            try
            {
                var securityLogin = _logic.Get(securityLoginId);
                return securityLogin != null ? Ok(securityLogin) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            try
            {
                _logic.Add(securityLoginPocos);
                return Ok();
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        public ActionResult PutSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            try
            {
                _logic.Update(securityLoginPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        public ActionResult DeleteSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            try
            {
                _logic.Delete(securityLoginPocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
    }
}
