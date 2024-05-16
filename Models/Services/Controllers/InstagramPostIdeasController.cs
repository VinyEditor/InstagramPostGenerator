[ApiController]
[Route("api/[controller]")]
public class InstagramPostIdeasController : ControllerBase
{
    private readonly ChatGPTService _chatGPTService;
    private readonly ILogger<InstagramPostIdeasController> _logger;

    public InstagramPostIdeasController(ChatGPTService chatGPTService, ILogger<InstagramPostIdeasController> logger)
    {
        _chatGPTService = chatGPTService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> GeneratePostIdeas([FromBody] string topic)
    {
        try
        {
            var postIdeas = await _chatGPTService.GeneratePostIdeas(topic);
            return Ok(postIdeas);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Failed to generate post ideas");
            await Task.Delay(TimeSpan.FromSeconds(10));
            return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable, please try again later");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate post ideas");
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to generate post ideas");
        }
    }
}
