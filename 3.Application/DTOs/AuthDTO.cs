namespace _3.Application.DTOs
{
    public class AuthDTO
    {
        public Guid UsuarioId { get; set; }

        public string? NombreUsuario { get; set; }

        public string? Token { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
