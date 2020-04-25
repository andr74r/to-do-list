import { SET_ISSUE_FILTER } from './IssueFilterActionsType';

export const setIssueFilter = (filter) => {
    return {
        type: SET_ISSUE_FILTER,
        filter: filter
    };
}