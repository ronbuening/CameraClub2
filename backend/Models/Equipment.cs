using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rating { get; set; } // 1-10
        public string? Review { get; set; }
        public string UserID { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
