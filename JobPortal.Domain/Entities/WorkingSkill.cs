using JobPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class WorkingSkill : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
