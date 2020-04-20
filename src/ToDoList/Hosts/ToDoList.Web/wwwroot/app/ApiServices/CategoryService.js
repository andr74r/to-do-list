import axios from 'axios';

export default class CategoryService {
    loadCategories() {
        return axios.get('/api/categories');
    }
}