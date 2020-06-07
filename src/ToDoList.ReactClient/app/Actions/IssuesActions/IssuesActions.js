import { SET_ISSUES, ADD_ISSUE, UPDATE_ISSUE, DELETE_ISSUE } from './IssuesActionsType';

import IssueService from '../../ApiServices/IssueService';

const issueService = new IssueService();

export const setIssues = (issues) => {
    return {
        type: SET_ISSUES,
        issues: issues
    };
}

export const createIssue = (categoryId, name) => {
    return dispatch => {
        issueService.createIssue(categoryId, name)
            .then(response => {
                dispatch({
                    type: ADD_ISSUE,
                    issue: response.data
                })
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export const changeIssueStatus = (categoryId, issueName) => {
    return dispatch => {
        issueService.changeIssueStatus(categoryId, issueName)
            .then(response => {
                dispatch({
                    type: UPDATE_ISSUE,
                    issue: response.data
                })
            })
            .catch(error => {
                console.log(error);
            })
    }
}

export const deleteIssue = (categoryId, issueName) => {
    return dispatch => {
        issueService.deleteIssue(categoryId, issueName)
            .then(() => {
                dispatch({
                    type: DELETE_ISSUE,
                    issueName: issueName
                });
            })
            .catch(error => {
                console.log(error);
            });
    }
}