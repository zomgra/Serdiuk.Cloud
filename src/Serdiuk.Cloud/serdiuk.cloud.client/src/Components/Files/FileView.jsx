import React, { useState } from 'react'
import { changePublicFile, downloadFile, renameFile } from '../../Utils/Services/FileService';

export const FileView = ({ file }) => {
    const [isEdit, setEdit] = useState(false);
    const [name, setName] = useState(file.name);

    async function handleEdit() {
        await setEdit(!isEdit)
        if (file.name != name) {
            await renameFile(name, file.id);
            file.name = name;
        }
    }

    async function handleChangePublic(){
        console.log(file.id);
        var res = await changePublicFile(file.id);
        if(res){
            file.isPublic = !file.isPublic;
        }
    }

    return (
        <div className={`d-flex row p-4 flex-grow-1 col-4 m-3 rounded border ${file.isPublic ? 'border-success' : 'border-danger'}`}>
            <div className='row col-12'>
                <div className='col-12 row'>
                    <div className="col-5">
                        {isEdit ? (
                            <input value={name} onChange={(e) => setName(e.target.value)} />
                        ) : (
                            <p className='font-monospace'>{file.name}</p>
                        )}
                    </div>
                    <div className="col-1">
                        <i className="fa clickable fa-pencil fa-lg" aria-hidden="true" onClick={handleEdit}></i>
                    </div>
                </div>
            </div>
            <div className='col-12 row align-items-center mt-auto'>
                <div className='col'>
                    <a className='btn btn-sm btn-info mx-5 my-2' onClick={() => downloadFile(file.id)}>
                        Download <i className="fa fa-download fa-lg" aria-hidden="true"></i>
                    </a>
                </div>
                <div className="col">
                    <a onClick={handleChangePublic} className='clickable btn btn-sm btn-success mx-5 my-2'>
                        Change Public <i  className="fa fa-user-secret" aria-hidden="true"></i>
                    </a>
                </div>
            </div>
        </div>
    )
}
