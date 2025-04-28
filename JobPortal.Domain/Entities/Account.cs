using JobPortal.Domain.Enums;
using JobPortal.Domain.Enums.Statuses;

namespace JobPortal.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string ProviderUserId { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Applicant;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public AccountStatus Status { get; set; } = AccountStatus.PendingVerification;

        public UserProfile? UserProfile { get; set; }
    }
}
