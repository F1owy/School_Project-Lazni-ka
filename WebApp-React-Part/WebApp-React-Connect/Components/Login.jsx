import './Login.css';

function Login() {
  return (
    <div className="login-container">
      <div className="login-form-wrapper">
        <h1>Prihlásenie</h1>
        <form className="login-form">
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
          <button type="submit" className="submit-button">Prihlásiť sa</button>
        </form>
      </div>
    </div>
  );
}

export default Login;
