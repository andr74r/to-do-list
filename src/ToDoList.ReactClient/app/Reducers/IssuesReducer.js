import { ADD_ISSUE, DELETE_ISSUE, SET_ISSUES, UPDATE_ISSUE  } from '../Actions/IssuesActions/IssuesActionsType';

export const issuesReducer = (state = [], action) => {
    switch(action.type) {
        case ADD_ISSUE:
            state.push(action.issue);
            return [...state.sortById()];
        case DELETE_ISSUE:
            return state
                .removeItemByName(action.issueName)
                .sortById();
        case SET_ISSUES:
            return action.issues.sortById();
        case UPDATE_ISSUE:
            return state
                .replaceItemById(action.issue)
                .sortById();
        default:
            return state;
    }
}