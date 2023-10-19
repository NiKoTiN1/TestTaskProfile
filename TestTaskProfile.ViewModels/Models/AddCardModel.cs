﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskProfile.ViewModels.Models
{
    public class AddCardModel
    {
        [Required]
        [MaxLength(19)]
        public string Number { get; set; }

        [Required]
        public DateTime Valid { get; set; }

        [Required]
        [MaxLength(100)]
        public string CardHolderName { get; set; }

        [Required]
        [MaxLength(3)]
        public string CVV { get; set; }
    }
}