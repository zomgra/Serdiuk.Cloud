import React, {useState, useEffect} from 'react'
import { FILE_URL } from '../../Utils/Configs/Constants';
import { downloadFile, getAllFiles } from '../../Utils/Services/FileService';


const FileList = () => {
    const [files, setFiles] = useState([]);

    useEffect(() => {
      async function getFiles(){
        let files = await getAllFiles();
        setFiles(files);
      }
      getFiles();
    }, []);
  
    return (
      <div>
        <h2>Список файлов</h2>
        {files.map(file => (
          <div key={file.id}>
            <a onClick={()=>downloadFile(file.id)}>
              {file.name}
            </a>
          </div>
        ))}
      </div>
    );
  }

export default FileList