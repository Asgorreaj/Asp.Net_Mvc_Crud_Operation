using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication12.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public List<CartItem> Items { get; set; }
    }

    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public Food FoodItem { get; set; }

        public int Quantity { get; set; }
    }

    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
    }
}