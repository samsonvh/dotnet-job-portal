using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class Resume
    {
        public Guid Id { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime UploadDate { get; set; }

        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = new UserProfile();
    }
}
