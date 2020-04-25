import React from 'react';
import { render } from 'react-dom';

import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';

import { rootReducer } from './Reducers/RootReducer';

import { Root } from './Components/App';

const store = createStore(rootReducer, applyMiddleware(thunk));

render(
    <Provider store={store}>
        <Root />
    </Provider>,
    document.getElementById("content")
)