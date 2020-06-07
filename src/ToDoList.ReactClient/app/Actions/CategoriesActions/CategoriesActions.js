import { SET_CATEGORIES, ADD_CATEGORY, UPDATE_CATEGORY, DELETE_CATEGORY } from './CategoriesActionsType';

import CategoryService from '../../ApiServices/CategoryService';

import { selectCategory } from '../SelectedCategoryActions/SelectedCategoryActions';

const categoryService = new CategoryService();

export const loadCategories = () => {
    return dispatch => {
        categoryService.loadCategories()
            .then(response => {
                const categories = response.data;

                dispatch({
                    type: SET_CATEGORIES,
                    categories: categories
                });

                if (categories.length) {
                    dispatch(selectCategory(categories[0]));
                }
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
                dispatch({
                    type: ADD_CATEGORY,
                    category: response.data
                });
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export const updateCategory = (category) => {
    return dispatch => {
        categoryService.updateCategory(category)
            .then(response => {
                dispatch({
                    type: UPDATE_CATEGORY,
                    category: response.data
                })
            })
            .catch(error => {
                console.log(error);
            })
    }
}

export const deleteCategory = (id) => {
    return dispatch => {
        categoryService.deleteCategory(id)
            .then(() => {
                dispatch({
                    type: DELETE_CATEGORY,
                    categoryId: id
                });
            })
            .catch(error => {
                console.log(error);
            })
    }
}