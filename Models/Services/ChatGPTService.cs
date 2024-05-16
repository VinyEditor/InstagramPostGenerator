public class ChatGPTService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ChatGPTService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> GeneratePostIdeas(string topic)
    {
        var request = new OpenAIRequestDto
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<Message>
            {
                new Message { Role = "system", Content = "You are a helpful assistant." },
                new Message { Role = "user", Content = $"Generate 3 Instagram post ideas based on the topic: {topic}" }
            }
        };

        var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ChatGPTResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (result.Choices.Count > 0)
        {
            var ideas = result.Choices[0].Message.Content.Split('\n').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            return string.Join("\n", ideas.Take(3));
        }

        throw new Exception("Failed to generate post ideas");
    }
}

public class ChatGPTResponse
{
    public List<Choice> Choices { get; set; }
}

public class Choice
{
    public Message Message { get; set; }
}
