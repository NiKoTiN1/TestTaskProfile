﻿using System.ComponentModel.DataAnnotations;

namespace TestTaskProfile.ViewModels.Models
{
    public class TokenModel
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
