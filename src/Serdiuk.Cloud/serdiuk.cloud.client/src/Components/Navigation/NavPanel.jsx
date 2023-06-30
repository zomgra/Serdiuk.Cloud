import React from 'react'
import { canUseToken } from '../../Utils/Services/TokenService'

const NavPanel = () => {
    function handleBrandClick() {
        window.location.href = '/'
    }
    function handleViewFiles() {
        window.location.href = '/'
    }
    function handleUploadFile() {
        window.location.href = '/upload'
    }
    function handleLogOut() {

    }
    let token = canUseToken();
    return (
        <div>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container">
                    <a className="navbar-brand" onClick={handleBrandClick}>Cloud Service</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            <li className="nav-item clickable">
                                <a className="nav-link" onClick={handleViewFiles}>View files</a>
                            </li>
                            <li className="nav-item clickable">
                                <a className="nav-link" onClick={handleUploadFile}>Upload File</a>
                            </li>
                        </ul>
                        {

                            token ? (
                                    <>
                                        <button className="btn btn-primary ms-auto order-2" type="button" onClick={handleLogOut}>Log out</button>

                                    </>) : (
                                    <>

                                    </>
                                )
                        }
                    </div>
                </div>
            </nav>
        </div>
    )
}

export default NavPanel