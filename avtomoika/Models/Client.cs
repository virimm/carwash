using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace avtomoika.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Имя клиента")]
        [Required]
        //[StringLength(25, MinimumLength = 4)]
        public string Name { get; set; }

        [Display(Name = "Номер автомобиля")]
        [Required]
        //[StringLength(10, MinimumLength = 6)]
        public string CarNumber { get; set; }


        public List<Order> Orders { get; set; }

        public Client()
        {
            Orders = new List<Order>();
        }
    }
}