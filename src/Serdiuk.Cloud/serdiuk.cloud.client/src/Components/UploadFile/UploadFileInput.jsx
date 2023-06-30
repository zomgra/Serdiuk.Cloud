import React, {useState} from 'react'
import { uploadFile } from '../../Utils/Services/FileService';

const UploadFileInput = ({handleFileChange}) => {
  
    const [selectedFile, setSelectedFile] = useState(null);
    
  
    return (
      <div>
        <input type="file" onChange={(event)=>setSelectedFile(event.target.files[0])} />
        <button onClick={(event)=>handleFileChange(selectedFile)}>Upload</button>
      </div>
    );
}

export default UploadFileInput