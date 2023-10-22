namespace TpIntegradorSofttek.DTOs
{
    public class UserLoginDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }

        
    }
}
