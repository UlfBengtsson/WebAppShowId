using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(name: "Hotel")]
        public int Hotel_Id { get; set; }
        public Hotel Hotel { get; set; }
    }
}