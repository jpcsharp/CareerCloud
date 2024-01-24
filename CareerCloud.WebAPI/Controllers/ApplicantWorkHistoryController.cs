using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [ApiController]
    [Route("api/careercloud/")]
    public class ApplicantWorkHistoryController : Controller
    {
        private readonly ApplicantWorkHistoryLogic _logic;
        private readonly List<ApplicantWorkHistoryPoco> _appliantWorkHistorylogic=new List<ApplicantWorkHistoryPoco>();
        public ApplicantWorkHistoryController()
        {
           // _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>());
        }

        [HttpGet, Route("workhistory/{appliantWorkHistoryId}")]
        [ProducesResponseType(typeof(ApplicantWorkHistoryPoco), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetApplicantWorkHistory(Guid appliantWorkHistoryId)
        {
            try
            {
                var workhistory = _logic.Get(appliantWorkHistoryId);
                return workhistory != null ? Ok(workhistory) : NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public ActionResult PostApplicantWorkHistory(ApplicantWorkHistoryPoco[] applicantWorkHistoryPoco)
        {
            try
            {
                foreach(var item in applicantWorkHistoryPoco)
                _appliantWorkHistorylogic.Add(item);

                //foreach (var item in applicantWorkHistoryPoco)
                //    _logic.Add(applicantWorkHistoryPoco);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PutApplicantWorkHistory(ApplicantWorkHistoryPoco[] ApplicantWorkHistoryPoco)
        {
            try
            {
                foreach(var item in ApplicantWorkHistoryPoco)
                    _appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    return Ok();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DeleteApplicantWorkHistory(ApplicantWorkHistoryPoco[] ApplicantWorkHistoryPoco)
        {
            try
            {
                foreach (var item in ApplicantWorkHistoryPoco)
                    //_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id);
                    if (item != null)
                    {
                        _appliantWorkHistorylogic.Remove(_appliantWorkHistorylogic.FirstOrDefault(p => p.Id == item.Id));
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
