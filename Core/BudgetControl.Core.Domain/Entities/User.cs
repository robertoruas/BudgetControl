using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Core.Domain.Entities
{
    public sealed class User : Entity
    {
        public User(string name, string password, string username, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), $"'{nameof(name)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), $"'{nameof(password)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username), $"'{nameof(username)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), $"'{nameof(email)}' cannot be null or empty.");
            }

            Name = name;
            Password = password;
            Username = username;
            Email = email;
            Status = UserStatus.Active;
        }

        public User(int id, string name, string password, string username, string email, UserStatus status, DateTime? blockDate = null, BlockReason? reason = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), $"'{nameof(name)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), $"'{nameof(password)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username), $"'{nameof(username)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), $"'{nameof(email)}' cannot be null or empty.");
            }

            Id = id;
            Name = name;
            Password = password;
            Username = username;
            Email = email;
            Status = status;
            BlockDate = blockDate;
            Reason = reason;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public UserStatus Status { get; private set; }

        public DateTime? BlockDate { get; private set; }

        public BlockReason? Reason { get; private set; }


        public void SetDisabled() => Status = UserStatus.Disabled;

        public void SetActive() => Status = UserStatus.Active;

        public void SetBlockedWithWrongPassReason()
        {
            Status = UserStatus.Blocked;
            BlockDate = DateTime.UtcNow;
            Reason = BlockReason.WrongPass;
        }

        public void SetBlockedWithSuspiciousActionReason()
        {
            Status = UserStatus.Blocked;
            BlockDate = DateTime.UtcNow;
            Reason = BlockReason.SuspiciousAction;
        }

        public void SetBlockedWithDefaulterReason()
        {
            Status = UserStatus.Blocked;
            BlockDate = DateTime.UtcNow;
            Reason = BlockReason.Defaulter;
        }

        public void SetUnblocked()
        {
            Status = UserStatus.Active;
            Reason = null;
            BlockDate = null;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password), $"'{nameof(password)}' cannot be null or whitespace.");
            }

            Password = password;
        }

    }

    public enum UserStatus
    {
        Disabled = 0,
        Active = 1,
        Blocked = 2
    }

    public enum BlockReason
    {
        WrongPass = 0,
        SuspiciousAction = 1,
        Defaulter = 2
    }
}
