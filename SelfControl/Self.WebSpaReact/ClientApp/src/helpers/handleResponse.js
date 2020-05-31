import history from '../helpers/history';

export function handleResponse(response) {
    if (!response.ok) {
        if ([401, 403].indexOf(response.status) !== -1) {
            history.push('/logout');

            window.location.reload(true);
        }
        
        const error = response.statusText;

        return Promise.reject(error);
    }

    return response.json();
}