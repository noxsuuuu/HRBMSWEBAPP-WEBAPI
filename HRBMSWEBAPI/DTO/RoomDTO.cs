using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HRBMSWEBAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HRBMSWEBAPI.DTO
{
    public class RoomDTO
    {

      /*  [DisplayName("Room ID")]
        [Key]
        public int Id { get; set; }
*/
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }


        [DisplayName("Room Status")]
        public bool Status { get; set; }


         //[ValidateNever]
         //public RoomCategories Category { get; set; }
 

        public RoomDTO() { }

        public RoomDTO( int categoryId, bool status)
        {
            //Id = id;
            CategoryId = categoryId;
            Status = status;
        }
    }
}
