import { SET_CATEGORIES } from './CategoriesActionsType';

import CategoryService from '../../ApiServices/CategoryService';

const categoryService = new CategoryService();

export const loadCategories = dispatch => {
    categoryService.loadCategories()
        .then((response) => {
            dispatch(setCategories(response.data));
        })
        .catch((error) => {
            console.log(error);
        });
}

export const setCategories = (categories) => {
    return {
        type: SET_CATEGORIES,
        categories: categories
    }
}