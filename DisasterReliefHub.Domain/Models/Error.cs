using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain.Models
{
    public class Error:Entity
    {
        public string Message { get; set; }

        public string Details { get; set; }

    }
}
