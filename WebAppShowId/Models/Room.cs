using System.ComponentModel.DataAnnotations;

namespace WebAppShowId.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int Beds { get; set; }
        public int BedRooms { get; set; }
        public int Number { get; set; }
        public bool isVacant { get; set; }
    }
}