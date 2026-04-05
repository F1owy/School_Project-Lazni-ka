import { useState } from 'react';
import './Admin.css';

function Admin() {
  const [adminPassword, setAdminPassword] = useState('');

  const handleAdminLogin = (e) => {
    e.preventDefault();
    console.log('Admin login attempt:', adminPassword);
    setAdminPassword('');
  };

  return (
    <div className="admin-page">
      <div className="admin-login-container">
        <h2>Admin Panel</h2>
        <form onSubmit={handleAdminLogin} className="admin-form">
          <div className="form-group">
            <label htmlFor="admin-password">Heslo</label>
            <input 
              type="password"
              id="admin-password"
              placeholder="Zadajte admin heslo"
              value={adminPassword}
              onChange={(e) => setAdminPassword(e.target.value)}
              className="admin-password-input"
            />
          </div>
          <button type="submit" className="admin-submit-btn">
            Prihlásiť
          </button>
        </form>
      </div>
    </div>
  );
}

export default Admin;
