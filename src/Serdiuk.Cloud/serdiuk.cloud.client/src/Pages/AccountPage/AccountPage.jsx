import React, { useState } from 'react'
import RegisterForm from '../../Components/Account/RegisterForm';
import LoginForm from '../../Components/Account/LoginForm';
import { Register } from '../../Utils/Services/AuthService';

const AccountPage = () => {

  function handleLogin(e) {
    e.preventDefault();
    let name = e.target.username.value;
    let email = e.target.email.value;
    let password = e.target.password.value;

    let data = Register(name,email,password);
    console.log(data);
  }
  function handleRegister(e) {

  }

  const [isLogin, setIsLogin] = useState();
  return (
    <form className='' onSubmit={isLogin ? handleLogin : handleRegister}>
      {isLogin ? (<RegisterForm />) : (<LoginForm />)}
      {isLogin ? (
        <div className='row justify-content-center'>
          <a className='btn btn-info col-3' onClick={() => setIsLogin(false)}>Already have account?</a>
          <button  type='submit' className='col-3 btn btn-success mx-1'>Submit</button>
        </div>) : (
        <div className='row justify-content-center'>
          <a className='btn btn-info col-3' onClick={() => setIsLogin(true)}>Create account</a>
          <button type='submit' className='col-3 btn btn-success mx-1'>Submit</button>
        </div>)}
    </form>
  )
}

export default AccountPage