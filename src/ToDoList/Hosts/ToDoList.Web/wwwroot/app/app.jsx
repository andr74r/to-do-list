import './Utils/ArrayExtensions';

import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import { render } from 'react-dom';

import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';

import { rootReducer } from './Reducers/RootReducer';

import HomePage from './Components/HomePage/HomePage';
import Login from './Components/Account/Login/Login';
import Register from './Components/Account/Register/Register';

const store = createStore(rootReducer, applyMiddleware(thunk));

render(
    <Provider store={store}>
        <BrowserRouter>
            <div>
                <Route exact path="/" component={HomePage} />
                <Route exact path="/login" component={Login} />
                <Route exact path="/register" component={Register} />
            </div>
        </BrowserRouter>
    </Provider>,
    document.getElementById("content")
)