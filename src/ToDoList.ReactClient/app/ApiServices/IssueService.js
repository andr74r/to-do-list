import axios from 'axios';

export default class IssueService {
    createIssue(categoryId, name) {
        return axios.post('/api/issues', {
            categoryId: categoryId,
            name: name
        });
    }

    changeIssueStatus(categoryId, issueName) {
        return axios.patch('/api/issues/changeStatus', {
            categoryId: categoryId,
            issueName: issueName
        });
    }

    deleteIssue(categoryId, issueName) {
        return axios.delete(`/api/issues?categoryId=${categoryId}&issueName=${issueName}`);
    }
}