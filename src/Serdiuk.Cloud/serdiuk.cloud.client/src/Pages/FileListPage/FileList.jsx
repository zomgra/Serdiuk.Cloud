import React, { useState, useEffect } from 'react'
import { getAllFiles } from '../../Utils/Services/FileService';
import { FileView } from '../../Components/Files/FileView';


const FileList = () => {
  const [files, setFiles] = useState([]);

  useEffect(() => {
    async function getFiles() {
      let files = await getAllFiles();
      setFiles(files);
    }
    getFiles();
  }, []);

  return (
    <div>
      <h2>List of Files</h2>
      {files.length !== 0 ? (
        <>
          {files.map(file => (
            <div className='row' key={file.id}>
              <FileView file={file} />
            </div>
          ))}
        </>
      ) : (<>
          <h4>You haven`t files</h4>
      </>)}
    </div>
  );
}

export default FileList