using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DisasterReliefHub.Domain.Models;

namespace DisasterReliefHub.Models
{
    public class SpecialDisaster
    {
        public List<Agency> Agencies { get; set; }

        public List<SafePerson> SafePeople { get; set; }

        public DwollaDonation Donation { get; set; }
    }
}