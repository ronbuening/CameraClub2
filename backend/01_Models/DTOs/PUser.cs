using System.ComponentModel.DataAnnotations;
namespace CameraClub2.Models;

public class PUser
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the avatar URL of the user.
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// Gets or sets the bio of the user.
    /// </summary>
    public string? Bio { get; set; }

    /// <summary>
    /// Gets or sets the email of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the club memberships associated with the user.
    /// </summary>
    public ICollection<ClubMembership>? ClubMemberships { get; set; }

    /// <summary>
    /// Gets or sets the equipment list associated with the user.
    /// </summary>
    public ICollection<Equipment>? EquipmentList { get; set; }

    /// <summary>
    /// Gets or sets the comments made by the user.
    /// </summary>
    public ICollection<Comment>? Comments { get; set; }

    /// <summary>
    /// Gets or sets the images uploaded by the user.
    /// </summary>
    public ICollection<Image>? Uploads { get; set; }

    /// <summary>
    /// Gets or sets the judging assignments associated with the user.
    /// </summary>
    public ICollection<JudgingAssignment>? JudgingAssignments { get; set; }
    public PUser() { }
    public PUser(Guid userId, string displayName, string? avatarUrl, string? bio, string email, string password)
    {
        UserId = userId;
        DisplayName = displayName;
        AvatarUrl = avatarUrl;
        Bio = bio;
        Email = email;
        Password = password;
        ClubMemberships = new List<ClubMembership>();
        EquipmentList = new List<Equipment>();
        Comments = new List<Comment>();
        Uploads = new List<Image>();
        JudgingAssignments = new List<JudgingAssignment>();
    }
    public PUser(User _user)
    {
        UserId = _user.UserId;
        DisplayName = _user.DisplayName;
        AvatarUrl = _user.AvatarUrl;
        Bio = _user.Bio;
        Email = _user.Email;
        ClubMemberships = _user.ClubMemberships ?? new List<ClubMembership>();
        EquipmentList = _user.EquipmentList ?? new List<Equipment>();
        Comments = _user.Comments ?? new List<Comment>();
        Uploads = _user.Uploads ?? new List<Image>();
        JudgingAssignments = _user.JudgingAssignments ?? new List<JudgingAssignment>();
    }
    
}