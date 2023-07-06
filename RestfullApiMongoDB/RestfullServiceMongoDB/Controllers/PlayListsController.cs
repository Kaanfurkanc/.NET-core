using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RestfullServiceMongoDB.Models;
using RestfullServiceMongoDB.Services;

namespace RestfullServiceMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListsController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;

        public PlayListsController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetAllAsync()
        {
            return Ok(await _mongoDbService.GetAllAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PlayList>> GetByIdAsync(string id)
        {
           
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> newPlayListAsync([FromBody] PlayList playList)
        {
            await _mongoDbService.CreateAsync(playList);
            return CreatedAtAction(nameof(GetByIdAsync), new {id = playList.Id} , playList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id,[FromBody] string movieId)
        {
            await _mongoDbService.UpdateAsync(id, movieId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            await _mongoDbService.RemoveAsync(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveManyAsync(string key,string option)
        {
            await _mongoDbService.RemoveManyAsync(key, option);
            return Ok();
        }
    }
}
