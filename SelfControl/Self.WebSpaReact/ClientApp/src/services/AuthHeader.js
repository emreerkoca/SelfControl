export default function authHeader() {
    const userToken = JSON.parse(localStorage.getItem('user-info') || '{}').token;

    if (userToken) {
        return 'Bearer ' + userToken;
    } 

    return '';
}