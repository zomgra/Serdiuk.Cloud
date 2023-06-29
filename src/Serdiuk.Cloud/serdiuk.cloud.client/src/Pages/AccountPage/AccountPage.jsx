import React, { useState } from 'react'
import RegisterForm from '../../Components/Account/RegisterForm';
import LoginForm from '../../Components/Account/LoginForm';
import { Register, login } from '../../Utils/Services/AuthService';

const AccountPage = () => {

  function handleLogin(e) {
    e.preventDefault();
    let email = e.target.email.value;
    let password = e.target.password.value;
    login(email, password)
  }
  function handleRegister(e) {

    e.preventDefault();
    let name = e.target.username.value;
    let email = e.target.email.value;
    let password = e.target.password.value;

    Register(name, email, password);
  }

  const [isLogin, setIsLogin] = useState();
  return (
    <form className='justify-content-center mt-5' style={{ display: 'inline-block' }} onSubmit={isLogin ? handleLogin : handleRegister}>
      {isLogin ? (<LoginForm />) : (<RegisterForm />)}

      {isLogin ? (
        <div className='row justify-content-center'>
          <a className='btn btn-info col-3' onClick={() => setIsLogin(false)}>Create account</a>
          <button type='submit' className='col-3 btn btn-success mx-4'>Log in</button>
        </div>
      ) : (
        <div className='row justify-content-center'>
          <a className='btn btn-info col-3' onClick={() => setIsLogin(true)}>Already have account?</a>
          <button type='submit' className='col-3 btn btn-success mx-4'>Submit</button>
        </div>
      )}
    </form>
  )
}

export default AccountPage