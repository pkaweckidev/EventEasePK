// Services/CartService.cs
using EventManagerPK.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManagerPK.Services
{
    public interface ICartService
    {
        event Action OnChange;
        List<CartItem> CartItems { get; }
        void AddToCart(Event eventItem);
        void RemoveFromCart(int eventId);
        void ClearCart();
        decimal GetTotal();
        int GetCartItemCount();
        int GetItemCount();
        event Action OnCartChanged;
        void NotifyCartChanged();

    }

    public class CartService : ICartService
    {
        private List<CartItem> _cartItems = new();

        public event Action OnChange;
        public List<CartItem> CartItems => _cartItems;


        public void AddToCart(Event eventItem)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.Event.Id == eventItem.Id);

            if (existingItem == null)
            {
                _cartItems.Add(new CartItem { Event = eventItem, Quantity = 1 });
            }
            else
            {
                existingItem.Quantity++;
            }

            OnChange?.Invoke();
            NotifyCartChanged();
        }

        public void RemoveFromCart(int eventId)
        {
            var item = _cartItems.FirstOrDefault(item => item.Event.Id == eventId);
            if (item != null)
            {
                _cartItems.Remove(item);
                OnChange?.Invoke();
                NotifyCartChanged();
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
            OnChange?.Invoke();
        }

        public decimal GetTotal() => _cartItems.Sum(item => item.Event.Price * item.Quantity);

        public int GetCartItemCount() => _cartItems.Sum(item => item.Quantity);

        public int GetItemCount()
        {
            return CartItems.Sum(item => item.Quantity);
        }
        public event Action OnCartChanged;

        public void NotifyCartChanged()
        {
            OnCartChanged?.Invoke();
        }

    }
}