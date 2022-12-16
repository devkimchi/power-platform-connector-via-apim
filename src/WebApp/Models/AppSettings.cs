namespace WebApp.Models
{
    public class AppSettings
    {
        public virtual AuthSettings? ApiKeyAuth { get; set; } = default;
        public virtual AuthSettings? BasicAuth { get; set; } = default;
        public virtual AuthSettings? AuthCodeAuth { get; set; } = default;
    }

    public class AuthSettings
    {
        public virtual string? Endpoint { get; set; } = default;
    }
}