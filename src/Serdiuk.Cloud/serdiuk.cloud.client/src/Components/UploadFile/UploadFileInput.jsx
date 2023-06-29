import React, {useState} from 'react'
import { FILE_URL } from '../../Utils/Configs/Constants';
import { uploadFile } from '../../Utils/Services/FileService';

const UploadFileInput = () => {
  
    const [selectedFile, setSelectedFile] = useState(null);

    const handleFileChange = (event) => {
      setSelectedFile(event.target.files[0]);
    };
  
    return (
      <div>
        <input type="file" onChange={handleFileChange} />
        <button onClick={()=>uploadFile(selectedFile)}>Upload</button>
      </div>
    );
}

export default UploadFileInput