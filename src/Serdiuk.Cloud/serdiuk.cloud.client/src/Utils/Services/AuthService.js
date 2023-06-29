import { AUTH_URL } from "../Configs/Constants";
import { setNewTokens } from "./TokenService";

export async function tryRefreshToken() {
    const refresh = localStorage.getItem('refresh');
    const access = localStorage.getItem('token')
    if (!refresh) return false;

    const url = `${AUTH_URL}/Refresh`;
    const data = {
        accessToken: access,
        refreshToken: refresh
    };

    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        const result = await response.json();
        console.log(result);

        return !result.Result;

    } catch (error) {
        console.error('An error occurred:', error);
        return false;
    }
}

export async function Register(name, email, password) {
    let data = JSON.stringify({ name, email, password });
    const response = await fetch(`${AUTH_URL}/register`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: data
    })
        .then(async responce => {
            let data = await responce.json();
            if (!data.result)
                throw new Error(data.errors.join(', '))

            setNewTokens(data.token, data.refresh);

            return data;
        })
        .catch(e => { console.log(e) });

    return response;
}