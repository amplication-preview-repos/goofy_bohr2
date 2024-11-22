namespace ChatGptAppBackend.APIs.Dtos;

public class MessageUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
