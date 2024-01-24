using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class SecurityRoleController : Controller
    {
        private readonly SecurityRoleLogic _logic;
        private readonly List<SecurityRolePoco> _securityRolePocologic=new List<SecurityRolePoco>();
        public SecurityRoleController()
        {
            _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>());
        }

        [HttpGet, Route("securityRole/{securityRoleId}")]
        [ProducesResponseType(typeof(SecurityRolePoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetSecurityRole(Guid securityRoleId)
        {
            try
            {
                var securityRole = _logic.Get(securityRoleId);
                return securityRole != null ? Ok(securityRole) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            try
            {
                _logic.Add(securityRolePocos);
                return Ok();
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }

        public ActionResult PutSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            try
            {
                _logic.Update(securityRolePocos);
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
        public ActionResult DeleteSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            try
            {
                _logic.Add(securityRolePocos); 
                return Ok();

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
    }
}
