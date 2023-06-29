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

        const headers = new Headers();
        let token = await GetToken();
        headers.append('Authorization', `Bearer ${token}`);
        console.log(token);
        const formData = new FormData();
        formData.append('file', file);
        fetch(`${FILE_URL}/upload`, {
            method: 'POST',
            body: formData,
            headers: headers
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