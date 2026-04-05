import { useState } from 'react';
import './Home.css';

function Home({ products, addToCart }) {
  const [activeCategory, setActiveCategory] = useState('Všetky');

  const categories = ['Všetky', 'Kamery', 'Audio', 'Objektívy', 'Príslušenstvo'];

  const filteredProducts = activeCategory === 'Všetky'
    ? products
    : products.filter((p) => p.category === activeCategory);

  return (
    <div className="home-container">
      <div className="home-buttons">
        {categories.map((cat) => (
          <button
            key={cat}
            className={`home-button ${activeCategory === cat ? 'home-button-active' : ''}`}
            onClick={() => setActiveCategory(cat)}
          >
            {cat}
          </button>
        ))}
      </div>
      <div className="products-grid">
        {filteredProducts.map((product) => (
          <div key={product.id} className="product-card">
            <div className="product-category">{product.category}</div>
            <h3 className="product-name">{product.name}</h3>
            <p className="product-description">{product.description}</p>
            <div className="product-footer">
              <span className="product-price">€{product.price.toLocaleString()}</span>
              <button
                className="add-to-cart-btn"
                onClick={() => addToCart(product)}
              >
                Pridať do košíka
              </button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default Home;
