namespace ChatGptAppBackend.APIs.Dtos;

public class MessageWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
