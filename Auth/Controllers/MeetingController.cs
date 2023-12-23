using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Auth.Controllers
{
    [Route("api/meetingsstat")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public MeetingController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetStat() 
        {
            var users = await _repositoryManager.GetUserAsync();
            var meetings = await _repositoryManager.GetAllMeetingsUser();

            var usersList = new List<string>();
            var countList = new List<int>();
            foreach (var user in users) 
            {
                usersList.Add(user.Id);
                countList.Add(meetings.Where(x => x.IdUser.ToString() == user.Id).Count());
            }

            return Ok(Tuple.Create(usersList, countList));
        }
    }
}
