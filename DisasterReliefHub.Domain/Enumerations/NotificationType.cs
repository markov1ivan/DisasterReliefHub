using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain
{
    [Flags]
    public enum NotificationType: int
    {
        None = 1,
        Email = 2,
        Phone = 4
    }
}
