import { tryRefreshToken } from "./AuthService";

export function setNewTokens(access, refresh){
    localStorage.setItem('token', access);
    localStorage.setItem('refresh', refresh);

    window.location.href='/';
}

export function canUseToken() {

    const token = localStorage.getItem('token');
    if (!token) return false;

    const decodedToken = JSON.parse(atob(token.split('.')[1]));
    const expirationTime = decodedToken.exp;
    const currentTime = new Date().getTime() / 1000;

    if (currentTime >= expirationTime) {
        return tryRefreshToken();
    }
    else{
        return true;
    }
}

export async function GetToken() {
    const token = localStorage.getItem('token');
    return token;
}