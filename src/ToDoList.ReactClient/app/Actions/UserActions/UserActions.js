import { SET_USER } from './UserActionsType';

import AccountService from '../../ApiServices/AccountService';

const accountService = new AccountService();

export const setUser = (user) => {
    return {
        type: SET_USER,
        user: user
    }
}

export const loadUser = () => {
    return dispatch => {
        accountService.getUser()
            .then(response => {
                dispatch(setUser(response.data));
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export const login = (login, password, successCallback, failCallback) => {
    return dispatch => {
        accountService.login(login, password)
            .then(response => {
                if (response.data.isLoggedIn)
                {
                    dispatch(setUser(response.data));
                    
                    if (successCallback) {
                        successCallback();
                    }
                }
                else {
                    if (failCallback) {
                        failCallback();
                    }
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export const register = (email, phone, password, successCallback, failCallback) => {
    return dispatch => {
        accountService.register(email, phone, password)
            .then(response => {
                if (response.data.isLoggedIn)
                {
                    dispatch(setUser(response.data));
                    
                    if (successCallback) {
                        successCallback();
                    }
                }
                else {
                    if (failCallback) {
                        failCallback();
                    }
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export const signOut = (callback) => {
    return dispatch => {
        accountService.logout()
            .then(() => {
                dispatch(setUser({ isLoggedIn: false }));

                if (callback) {
                    callback();
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
}