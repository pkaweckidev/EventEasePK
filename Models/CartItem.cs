// Models/CartItem.cs
using System;

namespace EventManagerPK.Models
{
    public class CartItem
    {
        public Event Event { get; set; }
        public int Quantity { get; set; }
    }
}