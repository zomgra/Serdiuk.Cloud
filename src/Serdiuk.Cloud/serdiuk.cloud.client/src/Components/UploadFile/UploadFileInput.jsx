import React, {useState} from 'react'
import { FILE_URL } from '../../Utils/Configs/Constants';

const UploadFileInput = () => {
  
    const [selectedFile, setSelectedFile] = useState(null);

    const handleFileChange = (event) => {
      setSelectedFile(event.target.files[0]);
    };
  
    const handleUpload = () => {
      if (selectedFile) {
        const formData = new FormData();
        formData.append('file', selectedFile);
        fetch(`${FILE_URL}/upload`, {
          method: 'POST',
          body: formData
        })
        .then(response => response.json())
        .then(data => {
          console.log('File uploaded successfully');
         
        })
        .catch(error => {
          console.error('Error uploading file:', error);
          
        });
      }
    };
  
    return (
      <div>
        <input type="file" onChange={handleFileChange} />
        <button onClick={handleUpload}>Upload</button>
      </div>
    );
}

export default UploadFileInput