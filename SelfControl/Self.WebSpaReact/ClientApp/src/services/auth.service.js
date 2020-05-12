const API_URL = "https://localhost:44364/user/";

class AuthService {
    login(userName, password) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(
                { EMail: userName,
                Password: password })
        };

        return fetch("https://localhost:44364/user/authenticate", requestOptions)
        .then(res => res.json())
        .then(
            (result) => {
            localStorage.setItem("user-token", JSON.stringify(result.token));
          },
          (error) => {
            this.setState({
              isLoaded: true,
              error
            });
          }
        )
    }
}

export default new AuthService();