import { Link } from 'react-router-dom';
import './Navbar.css';

function Navbar({ cartCount }) {

  return (
    <nav className="navbar">
      <div className="navbar-container">
        <Link to="/" className="navbar-logo">
          PhotoShop
        </Link>
        <div className="searchbar-container">
          <input 
            type="text" 
            className="searchbar" 
            placeholder="Hľadať..."
          />
        </div>
        <ul className="navbar-menu">
          <li className="navbar-item">
            <Link to="/" className="navbar-link">
              Home
            </Link>
          </li>
          <li className="navbar-item">
            <Link to="/login" className="navbar-link">
              Login
            </Link>
          </li>
          <li className="navbar-item">
            <Link to="/register" className="navbar-link">
              Register
            </Link>
          </li>
          <li className="navbar-item">
            <Link to="/cart" className="navbar-link cart-link">
              <i className="fa-solid fa-cart-shopping"></i>
              <span className="cart-count">{cartCount}</span>
            </Link>
          </li>
          <li className="navbar-item navbar-item-admin">
            <Link to="/admin" className="navbar-link">
              Admin
            </Link>
          </li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;
