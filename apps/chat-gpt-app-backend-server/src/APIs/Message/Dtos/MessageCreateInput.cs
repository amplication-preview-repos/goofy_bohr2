namespace ChatGptAppBackend.APIs.Dtos;

public class MessageCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
