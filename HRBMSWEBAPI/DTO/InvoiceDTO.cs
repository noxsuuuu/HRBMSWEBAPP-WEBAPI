using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class InvoiceDTO
    {
        [Required]
        public DateTime? Check_In { get; set; }

        public DateTime? Check_Out { get; set; }

        public string Price { get; set; }

        public string Total_Price { get; set; }

        public int Guest_Id { get; set; }

        public int Booking_Id { get; set; }

        public int Room_Id { get; set; }

        public int Category_Id { get; set; }



        public InvoiceDTO()
        {

        }

        public InvoiceDTO(DateTime? check_In, DateTime? check_Out, string price, string total_Price, int guest_Id, int booking_Id, int room_Id, int category_Id)
        {
            Check_In = check_In;
            Check_Out = check_Out;
            Price = price;
            Total_Price = total_Price;
            Guest_Id = guest_Id;
            Booking_Id = booking_Id;
            Room_Id = room_Id;
            Category_Id = category_Id;
        }
    }
}
