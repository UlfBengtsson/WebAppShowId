using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppShowId.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
        public int Stars { get; set; }
    }
}