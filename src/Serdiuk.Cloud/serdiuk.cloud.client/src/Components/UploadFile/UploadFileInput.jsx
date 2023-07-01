import React, {useState} from 'react'

const UploadFileInput = ({handleFileChange}) => {
  
    const [selectedFile, setSelectedFile] = useState(null);
    
    return (
      <div className='d-flex justify-content-center'>
        <input type="file" className='form-control m-4' onChange={(event)=>setSelectedFile(event.target.files[0])} />
        <button className='btn btn-success m-4' onClick={(event)=>handleFileChange(selectedFile)}>Upload</button>
      </div>
    );
}
export default UploadFileInput