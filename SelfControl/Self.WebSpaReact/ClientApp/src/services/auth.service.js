import { handleResponse } from '../helpers/handleResponse';

const API_URL = "https://localhost:44364/user/";

class AuthService {
    signup(user) {
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
      };

      return fetch(API_URL + "register", requestOptions)
        .then(handleResponse)
        .then(
            (result) => {
              return result;
          },
          (error) => {
            return error;
          }
        )
    }

    login(userName, password) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(
                { EMail: userName,
                Password: password })
        };

        return fetch(API_URL +  "authenticate", requestOptions)
          .then(handleResponse)
          .then(
              (result) => {
                var userInfo = {
                  userId: result.id,
                  token: result.token
                };

                localStorage.setItem("user-info", JSON.stringify(userInfo));
            },
            (error) => {
              console.log(error);
            }
          )
    }

    logout() {
      localStorage.removeItem("user-info");
    }

    checkAuthentication() {
      return JSON.parse(localStorage.getItem('user-info') || '{}').token;
    }
}

export default new AuthService();