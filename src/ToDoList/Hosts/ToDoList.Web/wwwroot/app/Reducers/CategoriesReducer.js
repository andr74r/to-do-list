import { SET_CATEGORIES, ADD_CATEGORY, UPDATE_CATEGORY, DELETE_CATEGORY } from '../Actions/CategoriesActions/CategoriesActionsType';

export const categoriesReducer = (state = [], action) => {
    switch (action.type) {
        case SET_CATEGORIES:
            return action.categories;
        case ADD_CATEGORY:
            state.push(action.category);
            return [...state];
        case UPDATE_CATEGORY:
            let newState = removeCategory(state, action.category.id);
            newState.push(action.category);
            return newState;
        case DELETE_CATEGORY:
            newState = removeCategory(state, action.categoryId);
            return newState;
        default:
            return state;
    }
}

const removeCategory = (categories, id) => {
    return categories.filter(x => x.id != id);
}

