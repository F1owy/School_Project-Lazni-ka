import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { useState } from 'react';
import Navbar from '../Components/Navbar';
import Home from '../Components/Home';
import Login from '../Components/Login';
import Register from '../Components/Register';
import Admin from '../Components/Admin';
import Cart from '../Components/Cart';
import './App.css';

const products = [
  {
    id: 1,
    name: 'Sony FX6 Cinema Camera',
    price: 6299,
    category: 'Kamery',
    description: 'Profesionálna full-frame cinema kamera s výmenným objektívom, 4K 120fps, duálnym základným ISO a pokročilým autofokusom.'
  },
  {
    id: 2,
    name: 'Rode Wireless GO II',
    price: 299,
    category: 'Audio',
    description: 'Kompaktný bezdrôtový mikrofónový systém s dvoma vysielačmi, vstavaným nahrávaním a dosahom až 200 metrov.'
  },
  {
    id: 3,
    name: 'Sony FX30 Cinema Camera',
    price: 1890,
    category: 'Kamery',
    description: 'Cenovo dostupná APS-C cinema kamera s 4K 120fps, pokročilým autofokusom a kompaktným dizajnom pre tvorcov obsahu.'
  }
];

function App() {
  const [cart, setCart] = useState([]);

  const addToCart = (product) => {
    setCart((prev) => [...prev, { ...product, cartId: Date.now() }]);
  };

  const removeFromCart = (cartId) => {
    setCart((prev) => prev.filter((item) => item.cartId !== cartId));
  };

  return (
    <Router>
      <div className="app">
        <Navbar cartCount={cart.length} />
        <div className="content">
          <Routes>
            <Route path="/" element={<Home products={products} addToCart={addToCart} />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/admin" element={<Admin />} />
            <Route path="/cart" element={<Cart cart={cart} removeFromCart={removeFromCart} />} />
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App
