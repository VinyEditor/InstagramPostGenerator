public class OpenAIRequestDto
{
    public string Model { get; set; }
    public List<Message> Messages { get; set; }
}

public class Message
{
    public string Role { get; set; }
    public string Content { get; set; }
}
