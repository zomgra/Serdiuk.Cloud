import React, {useState, useEffect} from 'react'
import { FILE_URL } from '../../Utils/Configs/Constants';
import { downloadFile, getAllFiles } from '../../Utils/Services/FileService';
import { FileView } from '../../Components/Files/FileView';


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
          <div className='row' key={file.id}>
            <FileView file={file}/>
          </div>
        ))}
      </div>
    );
  }

export default FileList