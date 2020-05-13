export default function authHeader() {
    const userToken = JSON.parse(localStorage.getItem('user-token'));

    if (userToken) {
        return { Authorization: 'Bearer ' + userToken };
    } 

    return {};
}