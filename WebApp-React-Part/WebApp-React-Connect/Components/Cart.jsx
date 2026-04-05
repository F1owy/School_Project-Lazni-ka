import './Cart.css';

function Cart({ cart, removeFromCart }) {
  const total = cart.reduce((sum, item) => sum + item.price, 0);

  return (
    <div className="cart-container">
      <h2 className="cart-title">Košík</h2>
      {cart.length === 0 ? (
        <p className="cart-empty">Košík je prázdny</p>
      ) : (
        <>
          <div className="cart-items">
            {cart.map((item) => (
              <div key={item.cartId} className="cart-item">
                <div className="cart-item-info">
                  <span className="cart-item-category">{item.category}</span>
                  <h3 className="cart-item-name">{item.name}</h3>
                  <p className="cart-item-description">{item.description}</p>
                  <div className="cart-item-details">
                    <span className="cart-item-price">€{item.price.toLocaleString()}</span>
                  </div>
                </div>
                <button
                  className="cart-remove-btn"
                  onClick={() => removeFromCart(item.cartId)}
                >
                  Odstrániť
                </button>
              </div>
            ))}
          </div>
          <div className="cart-total">
            <span>Celkom:</span>
            <span className="cart-total-price">€{total.toLocaleString()}</span>
          </div>
        </>
      )}
    </div>
  );
}

export default Cart;
