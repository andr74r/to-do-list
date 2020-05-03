import { combineReducers } from 'redux';

import { categoriesReducer } from './CategoriesReducer';
import { issuesReducer } from './IssuesReducer';
import { selectedCategoryReducer } from './SelectedCategoryReducer';
import { issueFilterReducer } from './IssueFilterReducer';
import { userReducer } from './UserReducer';

export const rootReducer = combineReducers({
    categoriesStore: categoriesReducer,
    issuesStore: issuesReducer,
    selectedCategoryStore: selectedCategoryReducer,
    issueFilterStore: issueFilterReducer,
    userStore: userReducer
});