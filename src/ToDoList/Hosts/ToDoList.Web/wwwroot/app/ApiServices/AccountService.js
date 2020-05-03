import axios from 'axios';

export default class AccountService {
    login(login, password) {
        return axios.post('api/account/login', {
            login: login,
            password: password
        });
    }

    register(email, phone, password) {
        return axios.post('api/account/register', {
            email: email,
            phone: phone,
            password: password
        });
    }

    logout() {
        return axios.post('api/account/logout');
    }

    getUser() {
        return axios.get('api/account/user');
    }
}