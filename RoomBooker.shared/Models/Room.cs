namespace RoomBooker.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
