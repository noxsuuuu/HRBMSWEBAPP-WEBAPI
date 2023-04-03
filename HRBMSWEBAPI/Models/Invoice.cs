namespace HRBMSWEBAPI.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public DateTime? Check_In { get; set; }

        public DateTime? Check_Out { get; set; }

        public string Price { get; set; }

        public string Total_Price { get; set; }

        public int Guest_Id { get; set; }

        public int Booking_Id { get; set; }

        public int Room_Id { get; set; }

        public int Category_Id { get; set; }


    }
}
