import React from 'react';
import { render } from 'react-dom';

import { Provider } from 'react-redux';
import { createStore } from 'redux';

import { rootReducer } from './Reducers/RootReducer';

import { Root } from './Components/App';

const store = createStore(rootReducer);

render(
    <Provider store={store}>
        <Root />
    </Provider>,
    document.getElementById("content")
)