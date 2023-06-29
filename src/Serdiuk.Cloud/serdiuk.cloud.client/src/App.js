import { Route, Routes } from 'react-router-dom';
import './App.css';
import FileList from './Pages/FileListPage/FileList';
import UploadFilePage from './Pages/UploadFilePage/UploadFilePage';
import AccountPage from './Pages/AccountPage/AccountPage';
import PrivateRouter from './Utils/Routes/PrivateRouter';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState } from 'react';
import NavPanel from './Components/Navigation/NavPanel';


function App() {

  useEffect(() => {
    
  }, [])

  return (
    
    <div className="d-flex justify-content-center">
      <Routes>
        <Route element={<PrivateRouter />}>
          <Route path='/' element={<FileList />}></Route>
          <Route path='/upload' element={<UploadFilePage />}></Route>
        </Route>
        <Route path='/account' element={<AccountPage />}></Route>
      </Routes>
    </div>
  );
}

export default App;
