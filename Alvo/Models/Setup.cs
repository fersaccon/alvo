using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alvo.Models
{
    public class Setup
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public IEnumerable<SensorSetup> SensoresSetup { get; set; }
    }
}
