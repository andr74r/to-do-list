import { combineReducers } from 'redux';
import { ignoreActions } from 'redux-ignore';

import { categoriesReducer } from './CategoriesReducer';

export const rootReducer = combineReducers({
    categoriesStore: categoriesReducer
});