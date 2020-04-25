import { ADD_ISSUE, DELETE_ISSUE, SET_ISSUES, UPDATE_ISSUE  } from '../Actions/IssuesActions/IssuesActionsType';

export const issuesReducer = (state = [], action) => {
    switch(action.type) {
        case ADD_ISSUE:
            state.push(action.issue);
            return [...state];
        case DELETE_ISSUE:
            let newState = removeIssue(state, action.issueId);
            return newState;
        case SET_ISSUES:
            return action.issues;
        case UPDATE_ISSUE:
            newState = removeIssue(state, action.issue.id);
            newState.push(action.issue);
            return newState;
        default:
            return state;
    }
}

const removeIssue = (issues, id) => {
    return issues.filter(x => x.id != id);
}