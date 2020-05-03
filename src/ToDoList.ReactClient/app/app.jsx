import './Utils/ArrayExtensions';

import React, { Fragment } from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import { render } from 'react-dom';

import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';

import { rootReducer } from './Reducers/RootReducer';

import HomePage from './Components/HomePage/HomePage';
import Login from './Components/Account/Login/Login';
import Register from './Components/Account/Register/Register';
import Header from './Components/Header/Header';
import Footer from './Components/Footer/Footer';

const store = createStore(rootReducer, applyMiddleware(thunk));

render(
    <Provider store={store}>
        <Fragment>
            <Header />
            <BrowserRouter>
                <Fragment>
                    <Route exact path="/" component={HomePage} />
                    <Route exact path="/login" component={Login} />
                    <Route exact path="/register" component={Register} />
                </Fragment>
            </BrowserRouter>
            <Footer />
        </Fragment>
    </Provider>,
    document.getElementById("content")
)