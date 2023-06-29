import React from 'react'

const LoginForm = () => {
  return (
    <div style={{ display: 'inline-block', minWidth: '450px' }} className='justify-content-center'>
      <div className='mt-2 mb-3'>
        <input className='form-control w-100' name='name' placeholder='Username' />
      </div>
      <div className='mt-3 mb-3'>
        <input className='form-control w-100' name='password' type='password' placeholder='Password' />
      </div>
    </div>
  )
}

export default LoginForm