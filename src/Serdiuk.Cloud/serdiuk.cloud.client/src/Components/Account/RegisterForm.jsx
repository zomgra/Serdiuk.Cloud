import React from 'react'

const RegisterForm = () => {
  return (
    <div style={{display:'inline-block', minWidth:'450px'}} className='justify-content-center'>
      <div className='mt-2 mb-2'>
        <input className='form-control w-100' name='username' placeholder='Username' />
      </div>
      <div className='mt-2 mb-2'>
        <input className='form-control w-100' name='email' type={'email'} placeholder='example@mail.com' />
      </div>
      <div className='mt-2 mb-2'>
        <input className='form-control w-100' name='password' type='password' placeholder='Password' />
      </div>
    </div>
  )
}

export default RegisterForm