import axios from 'axios';

export default class CategoryService {
    loadCategories() {
        return axios.get('/api/categories');
    }

    createCategory(category) {
        return axios.post('/api/categories', category);
    }

    updateCategory(category) {
        return axios.put('/api/categories', category);
    }

    deleteCategory(id) {
        return axios.delete(`/api/categories/${id}`);
    }
}