using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain.Models
{
    [Table("Disaster")]
    public class Disaster : Entity
    {
        public String Name { get; set; }
        public string Description { get; set; }
        public List<Agency> Agencies { get; set; }
    }
}
