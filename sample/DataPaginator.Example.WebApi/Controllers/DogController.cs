using DataPaginator.Example.WebApi.Models;
using DataPaginator.Example.WebApi.Repository;
using DataPaginator.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataPaginator.Example.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private readonly IDogRepository _dogRepository;
        public DogController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetAsync()
        {
            return Ok(await _dogRepository.GetDogs());
        }

        [HttpGet("Paginated")]
        public async Task<ActionResult<PageModel<Dog>>> GetAsync([FromQuery] int page, [FromQuery]int pageSize)
        {
            return Ok(await _dogRepository.GetPaginatedDogs(page, pageSize));
        }
    }
}
