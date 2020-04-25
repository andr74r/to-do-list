import { SET_CATEGORIES, ADD_CATEGORY } from './CategoriesActionsType';

import CategoryService from '../../ApiServices/CategoryService';

const categoryService = new CategoryService();

export const loadCategories = () => {
    return dispatch => {
        categoryService.loadCategories()
            .then(response => {
                dispatch(setCategories(response.data));
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export const createCategory = (name) => {
    return dispatch => {
        categoryService.createCategory({ name: name })
            .then(response => {
                dispatch(addCategory(response.data));
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export const setCategories = (categories) => {
    return {
        type: SET_CATEGORIES,
        categories: categories
    }
}

export const addCategory = (category) => {
    return {
        type: ADD_CATEGORY,
        category: category
    }
}