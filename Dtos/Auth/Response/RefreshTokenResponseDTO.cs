namespace TodoAPI.Dtos.Auth.Response;

public class RefreshTokenResponseDTO 
{
    public string UserId { get; set; }
    public bool Success { get; set; }
    public List<string> Errors { get; set; }
}
