namespace ChatGptAppBackend.APIs.Dtos;

public class ConversationCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
