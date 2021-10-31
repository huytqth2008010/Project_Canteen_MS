using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Canteen_MS.Models
{
    public class Cart
    {
        private List<CartItem> cartItems;
        private int grandTotal;

        public Cart()
        {
            cartItems = new List<CartItem>();
        }

        public int GrandTotal { get => grandTotal; set => grandTotal = value; }
        public List<CartItem> CartItems { get => cartItems; } // readonly property

        public CartItem this[int index] // indexer
        {
            get => CartItems[index];
            set => CartItems[index] = value;
        }

        public void AddToCart(CartItem item)
        {
            // kiem tra xem sp da co trong ds hay chua
            // neu chua them bt
            // co roi thi chi them so luong
            int position = CheckExists(item);
            if (position >= 0)
            {
                CartItems[position].Qty += item.Qty;
            }
            else
            {
                CartItems.Add(item);
            }
            CalculateGrandTotal();
        }

        public void RemoveItem(int id)
        {
            foreach (var item in CartItems)
            {
                if (item.Product.Id == id)
                {
                    CartItems.Remove(item);
                    CalculateGrandTotal();
                    break;
                }
            }
        }

        public void CalculateGrandTotal()
        {
            int grand = 0;
            foreach (var item in CartItems)
            {
                grand += item.Product.Price * item.Qty;
            }
            GrandTotal = grand;
        }

        private int CheckExists(CartItem item)
        {
            for (int i = 0; i < CartItems.Count; i++)
            {
                if (CartItems[i].Product.Id == item.Product.Id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}