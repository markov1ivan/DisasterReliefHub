using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain
{
    [Flags]
    public enum NotificationType: int
    {
        Email = 1,
        Phone
    }
}
