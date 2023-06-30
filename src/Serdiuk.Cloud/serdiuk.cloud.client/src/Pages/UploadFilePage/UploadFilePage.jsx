import React, { useState } from 'react'
import UploadFileInput from '../../Components/UploadFile/UploadFileInput'
import { uploadFile } from '../../Utils/Services/FileService'

const UploadFilePage = () => {
  const [message, setMessage] = useState('');

  async function handleFileChange(file) {
    if (file) {
      let ok = await uploadFile(file);
      if(ok){
        window.location.href = '/';
      }
    } else {
      setMessage('Please, upload file');
    }
  }
  return (
    <div className='row'>
      <label>{message}</label>
      <UploadFileInput handleFileChange={handleFileChange} />
    </div>
  )
}

export default UploadFilePage