import { SET_CATEGORIES, ADD_CATEGORY } from '../Actions/CategoriesActions/CategoriesActionsType';

export const categoriesReducer = (state = [], action) => {
    switch (action.type) {
        case SET_CATEGORIES:
            return action.categories;
        case ADD_CATEGORY:
            state.push(action.category);
            return [...state];
        default:
            return state;
    }
}