using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWindSepet.Models
{
    public class Cart
    {

        Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();

        public List<CartItem> myCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void DeleteItem(int id)
        {
            if (_myCart.ContainsKey(id))//1
            {
                _myCart.Remove(id);
            }
        }

        public void AddItem(CartItem cartItem)//1
        {
            if (_myCart.ContainsKey(cartItem.Id))//1
            {
                _myCart[cartItem.Id].Quantity += cartItem.Quantity;
                return;

            }
            _myCart.Add(cartItem.Id, cartItem);
        }
    }
}