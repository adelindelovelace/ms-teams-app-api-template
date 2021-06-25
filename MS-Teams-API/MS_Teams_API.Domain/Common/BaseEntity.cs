using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Teams_API.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
