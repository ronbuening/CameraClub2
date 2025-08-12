using System.ComponentModel.DataAnnotations;
namespace CameraClub2.Models
{
    /// <summary>
    /// Represents a user in the system with basic profile information.
    /// </summary>
    public class CUser
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string RawPassword { get; set; }

        public CUser() { }
        public CUser(string _displayName, string _email, string _rawPassword, string _fullName = "")
        {
            DisplayName = _displayName;
            Email = _email;
            RawPassword = _rawPassword;
        }

    }
}