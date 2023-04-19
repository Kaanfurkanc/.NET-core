using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cancellation_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly ILogger<TokenController> _logger;
        public TokenController(ILogger<TokenController> logger)
        {
            //Dependency Injecion
           _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
            try
            {
                Enumerable.Range(1, 10).ToList().ForEach(x =>
                {

                    Thread.Sleep(1000);
                    token.ThrowIfCancellationRequested();

                });

                _logger.LogInformation("İstek başladı");

                await Task.Delay(6000, token);

                //Token.ThrowIfCancellationRequested();  Asenkron method olmadığında kontrol etmek için kullanırız . 

                var my_task = new HttpClient().GetStringAsync("https://www.google.com.tr");
                var data = await my_task;

                _logger.LogInformation("İstek bitti ");

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"İstek iptal edildi :" + ex.Message);

                return BadRequest();
            }

        }
    }
}
