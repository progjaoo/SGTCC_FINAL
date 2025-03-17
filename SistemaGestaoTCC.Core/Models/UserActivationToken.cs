using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestaoTCC.Core.Models
{
    public class UserActivationToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }

        [ForeignKey("UserId")]
        public Usuario User { get; set; }
    }
}
