import './Register.css';

function Register() {
  return (
    <div className="register-container">
      <div className="register-form-wrapper">
        <h1>Registrácia</h1>
        <form className="register-form">
          <div className="form-group">
            <label htmlFor="username">Používateľské meno</label>
            <input 
              type="text" 
              id="username" 
              name="username"
              placeholder="..."
            />
          </div>
          <div className="form-group">
            <label htmlFor="email">Email</label>
            <input 
              type="email" 
              id="email" 
              name="email"
              placeholder="..."
            />
          </div>
          <div className="form-group">
            <label htmlFor="password">Heslo</label>
            <input 
              type="password" 
              id="password" 
              name="password"
              placeholder="..."
            />
          </div>
          <button type="submit" className="submit-button">Registrovať sa</button>
        </form>
      </div>
    </div>
  );
}

export default Register;
