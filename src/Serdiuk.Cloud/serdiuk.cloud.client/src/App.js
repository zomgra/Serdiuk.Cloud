import { Route, Routes } from 'react-router-dom';
import './App.css';
import FileList from './Pages/FileListPage/FileList';
import UploadFilePage from './Pages/UploadFilePage/UploadFilePage';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path='/'element={<FileList/>}></Route>
        <Route path='/upload'element={<UploadFilePage/>}></Route>
      </Routes>
    </div>
  );
}

export default App;
