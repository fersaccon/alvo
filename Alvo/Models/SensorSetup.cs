using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alvo.Models
{
    public class SensorSetup
    {
        public int Id { get; set; }

        public int Ordem { get; set; }

        public int SetupId { get; set; }

        public Setup Setup { get; set; }

        public int SensorId { get; set; }

        public Sensor Sensor { get; set; }

    }
}
