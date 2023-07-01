import { FILE_URL } from "../Configs/Constants";
import { GetToken } from "./TokenService";

export async function getAllFiles() {
    let data = fetch(`${FILE_URL}/get-all`, {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${await GetToken()}`,
        },
    }).then(async data => await data.json());

    return data;
}

export async function uploadFile(file) {
    if (file) {
        const formData = new FormData();
        formData.append('file', file);
        const response = await fetch(`${FILE_URL}/upload`, {
            method: 'POST',
            body: formData,
            headers: {

                'Authorization': `Bearer ${await GetToken()}`,
            }
        })

        if (response.ok) {
            console.log('File uploaded successfully!');
        } else {
            console.error('Error uploading file:', response.statusText);
        }
        return response.ok;
    }
};

export async function renameFile(newName, id) {
    let data = await fetch(`${FILE_URL}/rename`, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${await GetToken()}`,
        },
        body: JSON.stringify({ newName, id })
    });

    return data.ok;
}

export async function removeFile(id) {
    let data = await fetch(`${FILE_URL}/remove/${id}`,{
        headers: {
            'Authorization': `Bearer ${await GetToken()}`,
            'Content-Type': 'application/json'
        },
        method:'DELETE',
    })
    return data.ok;
}

export async function downloadFile(id) {
    let data = fetch(`${FILE_URL}/download/${id}`, {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${await GetToken()}`,
        },
    })
        .then(response => {
            const contentDisposition = response.headers.get('Content-Disposition');
            const filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
            const matches = filenameRegex.exec(contentDisposition);
            const filename = matches && matches[1] ? matches[1].replace(/['"]/g, '') : 'file';
            return response.blob().then(blob => ({ blob, filename }));
        })
        .then(({ blob, filename }) => {
            const url = window.URL.createObjectURL(blob);
            const link = document.createElement('a');
            link.href = url;
            link.setAttribute('download', filename);
            document.body.appendChild(link);
            link.click();
        });
}
export async function changePublicFile(id) {
    let data = await fetch(`${FILE_URL}/public/${id}`, {
        method: "PUT",
        headers: {
            'Authorization': `Bearer ${await GetToken()}`,
        },
    })
    return data.ok;
}