namespace _3.Application.DTOs
{
    public class JWTConfiguracionDTO
    {
        public string? Key { get; set; }

        public string? Editor { get; set; }

        public string? Audiencia { get; set; }


        public double DuracionMinutos { get; set; }

        public TimeSpan ExpireTime { get; set; }
    }
}
