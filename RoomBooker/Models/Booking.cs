using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RoomBooker.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateOnly? DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }

        public int CustomerId { get; set; }
        public int RoomId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;

        [ValidateNever]
        public Room Room { get; set; } = null!;
    }
}
