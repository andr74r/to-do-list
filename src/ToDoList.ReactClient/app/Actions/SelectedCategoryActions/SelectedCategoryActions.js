import { SELECT_CATEGORY } from './SelectedCategoryActionsType';

import { setIssues } from '../IssuesActions/IssuesActions';

export const selectCategory = category => {
    return dispatch => {
        dispatch({
            type: SELECT_CATEGORY,
            category: category
        });
        dispatch(setIssues(category.issues));
    }
}