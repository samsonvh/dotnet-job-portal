using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Locations;

namespace JobPortal.Domain.Entities.Users
{
    public class Applicant : BaseUserProfile
    {
        public BaseLocation AddressLocation { get; set; } = new BaseLocation();
        public ICollection<UserSkill> Skills { get; set; } = new List<UserSkill>();
    }
}
