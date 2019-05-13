﻿using System.ComponentModel.DataAnnotations;

namespace ReceiptWebApp.Models
{
    public class Provider
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}