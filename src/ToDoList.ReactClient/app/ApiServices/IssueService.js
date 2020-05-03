import axios from 'axios';

export default class IssueService {
    loadIssues(categoryId) {
        return axios.get(`/api/issues?categoryId=${categoryId}`);
    }

    createIssue(categoryId, name) {
        return axios.post('/api/issues', {
            categoryId: categoryId,
            name: name
        });
    }

    changeIssueStatus(id, isCompleted) {
        return axios.patch('/api/issues/changeStatus', {
            id: id,
            isCompleted: isCompleted
        });
    }

    deleteIssue(id) {
        return axios.delete(`/api/issues/${id}`);
    }
}