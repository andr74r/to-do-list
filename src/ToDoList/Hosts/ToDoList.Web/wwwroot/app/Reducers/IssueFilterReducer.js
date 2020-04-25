import { SET_ISSUE_FILTER } from '../Actions/IssueFilterActions/IssueFilterActionsType';
import FilterType from '../Consts/FilterType';

export const issueFilterReducer = (state = FilterType.all, action) => {
    switch (action.type) {
        case SET_ISSUE_FILTER:
            return action.filter;
        default:
            return state;
    }
}