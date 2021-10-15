﻿using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesi.Common.DTOs.Login
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
