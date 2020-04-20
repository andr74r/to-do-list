import { SET_CATEGORIES } from '../Actions/CategoriesActions/CategoriesActionsType';

export const categoriesReducer = (state = [], action) => {
    switch (action.type) {
        case SET_CATEGORIES:
            return action.categories;
        default:
            return state;
    }
}