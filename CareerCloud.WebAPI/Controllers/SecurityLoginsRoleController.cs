using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;
        private readonly List<SecurityLoginsRolePoco> _securityLoginsRolePocologic=new List<SecurityLoginsRolePoco>();
        public SecurityLoginsRoleController()
        {
            _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>());
        }

        [HttpGet, Route("securityLoginsRole/{securityLoginRoleId}")]
        [ProducesResponseType(typeof(SecurityLoginsRolePoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetSecurityLoginsRole(Guid securityLoginRoleId)
        {
            try
            {
                var securityLoginsRole = _logic.Get(securityLoginRoleId);
                return securityLoginsRole != null ? Ok(securityLoginsRole) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            try
            {
                foreach (var item in securityLoginsRolePocos)
                    _securityLoginsRolePocologic.Add(item);

                //foreach (var item in securityLoginsRolePocos)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            try
            {
                foreach (var item in securityLoginsRolePocos)
                    _securityLoginsRolePocologic.FirstOrDefault(p => p.Id == item.Id);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            try
            {
                foreach (var item in securityLoginsRolePocos)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _securityLoginsRolePocologic.Remove(_securityLoginsRolePocologic.FirstOrDefault(p => p.Id == item.Id));
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
