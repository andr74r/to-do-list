import { SELECT_CATEGORY } from './SelectedCategoryActionsType';

import { loadIssues } from '../IssuesActions/IssuesActions';

export const selectCategory = categoryId => {
    return dispatch => {
        dispatch({
            type: SELECT_CATEGORY,
            categoryId: categoryId
        });
        dispatch(loadIssues(categoryId));
    }
}