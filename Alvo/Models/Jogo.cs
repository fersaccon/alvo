using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alvo.Models
{
    public class Jogo
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public int SetupId { get; set; }

        public Setup Setup { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public int Pontos { get; set; }
    }
}

