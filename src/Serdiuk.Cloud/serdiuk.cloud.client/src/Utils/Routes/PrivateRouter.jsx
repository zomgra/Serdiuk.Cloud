import React, { useEffect, useState } from 'react'
import { Navigate, Outlet } from 'react-router-dom';
import { canUseToken } from '../Services/TokenService';

const PrivateRouter = () => {
    const [isAuth, setAuthorize] = useState( false);
    const [isLoading, setIsLoading] = useState(true);


    useEffect(() => {
      async function setAuth() {
          setAuthorize(canUseToken())
          setIsLoading(false)
        }
        setAuth();
      }, [])
    
      if (isLoading) {
        return <div>Loading...</div>;
      }
      else {
        return (
            <>
            {isAuth ? <Outlet /> : <Navigate to="/account" />}
            </>
        )
      }
}

export default PrivateRouter