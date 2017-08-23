using System;
using System.ComponentModel.DataAnnotations;


namespace avtomoika.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Время создания заказа")]
        public DateTime Date { get; set; }

        [Display(Name = "Состояние заказа")]
        public string State { get; set; }

        //[Required]
        [Display(Name = "Номер Бокса")]
        public string BoxName { get; set; }

        [Required]
        public virtual Client Client { get; set; }
    }
}