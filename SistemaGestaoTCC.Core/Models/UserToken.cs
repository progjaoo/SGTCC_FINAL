using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Core.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Type { get; set; } // "ResetPassword" ou "AccountActivation"

        public virtual Usuario User { get; set; } // Relacionamento com a tabela de usuários
    }
}
