import { SET_ISSUES, ADD_ISSUE, UPDATE_ISSUE, DELETE_ISSUE } from './IssuesActionsType';

import IssueService from '../../ApiServices/IssueService';

const issueService = new IssueService();

export const loadIssues = (categoryId) => {
    return dispatch => {
        issueService.loadIssues(categoryId)
            .then(response => {
                dispatch({
                    type: SET_ISSUES,
                    issues: response.data
                })
            })
            .catch(error => {
                console.log(error);
            })
    }
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

export const changeIssueStatus = (id, isCompleted) => {
    return dispatch => {
        issueService.changeIssueStatus(id, isCompleted)
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

export const deleteIssue = (id) => {
    return dispatch => {
        issueService.deleteIssue(id)
            .then(() => {
                dispatch({
                    type: DELETE_ISSUE,
                    issueId: id
                });
            })
            .catch(error => {
                console.log(error);
            });
    }
}