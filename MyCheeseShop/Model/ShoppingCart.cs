namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        public List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];
        }

        public void AddItem(Cheese cheese, int quantity)
        {
            //add the cheese or increase the quantity
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item == null)
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            else
                    item.Quantity += quantity;

            // alert the listeners to the cart change
            OnCartUpdated?.Invoke(); 
            
        }

        public IEnumerable<CartItem> GetItems()
        {
            //return a copy of the items in the cart
            return _items;
        }

        public int Count()
        {
            // return the number of items in the cart
            return _items.Count;
        }

        public decimal Total()
        {
            //sum of all the items(prices) in the cart
            return _items.Sum(item => item.Cheese.Price * item.Quantity);
        }
        public void RemoveItem(Cheese cheese)
        {
            // removes cheese from the cart
            _items.RemoveAll(item => item.Cheese.Id == cheese.Id);
            // updates the cart
            OnCartUpdated?.Invoke();

        }

        public void RemoveItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is not null)
            {
                // if the quantity reaches 0 it removes the item from the cart
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                    _items.Remove(item);
            }
            // updates the cart
            OnCartUpdated?.Invoke();
        }

        public void clear()
        {
            //clears items
            _items.Clear();
            OnCartUpdated?.Invoke();    
        }

        public int GetQuantity(Cheese cheese)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id); ;
            return item?.Quantity ?? 0;
        }

        public void SetItems(IEnumerable<CartItem> items)
        {
            //set items in the cart
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }
    }
}
