namespace ChatGptAppBackend.APIs.Dtos;

public class ConversationUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
