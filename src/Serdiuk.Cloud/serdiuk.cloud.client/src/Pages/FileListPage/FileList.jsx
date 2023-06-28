import React, {useState, useEffect} from 'react'
import { FILE_URL } from '../../Utils/Configs/Constants';


const FileList = () => {
    const [files, setFiles] = useState([]);

    useEffect(() => {
      // Здесь вы можете сделать запрос к серверу для получения списка файлов
      fetch(`${FILE_URL}/get-all`)
        .then(response => response.json())
        .then(data => setFiles(data));
    }, []);
  
    return (
      <div>
        <h2>Список файлов</h2>
        {files.map(file => (
          <div key={file.id}>
            <a href={`${FILE_URL}/get/${file.id}`}>
              {file.name}
            </a>
          </div>
        ))}
      </div>
    );
  }

export default FileList