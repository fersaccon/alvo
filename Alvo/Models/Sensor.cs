using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alvo.Models
{
    public class Sensor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Ip { get; set; }

        public string Descricao { get; set; }
    }
}
