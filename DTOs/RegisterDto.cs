﻿namespace TpIntegradorSofttek.DTOs
{
    public class RegisterDto
    {
        public string Name { get; set; }

        public string Dni { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }

        public string Password { get; set; }
    }
}
