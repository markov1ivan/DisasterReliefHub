using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisasterReliefHub.Domain.Repository
{
    public interface IEntity: ICloneable
    {
        int Id { get; set; }
    }
}
