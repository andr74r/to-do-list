import { combineReducers } from 'redux';
import { ignoreActions } from 'redux-ignore';

import { categoriesReducer } from './CategoriesReducer';
import { issuesReducer } from './IssuesReducer';
import { selectedCategoryReducer } from './SelectedCategoryReducer';

export const rootReducer = combineReducers({
    categoriesStore: categoriesReducer,
    issuesStore: issuesReducer,
    selectedCategoryStore: selectedCategoryReducer
});