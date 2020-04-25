import { SET_CATEGORIES, ADD_CATEGORY, UPDATE_CATEGORY, DELETE_CATEGORY } from '../Actions/CategoriesActions/CategoriesActionsType';

export const categoriesReducer = (state = [], action) => {
    switch (action.type) {
        case SET_CATEGORIES:
            return action.categories.sortById();
        case ADD_CATEGORY:
            state.push(action.category);
            return [...state.sortById()];
        case UPDATE_CATEGORY:
            return state
                .replaceItemById(action.category)
                .sortById();
        case DELETE_CATEGORY:
            return state
                .removeItemById(action.categoryId)
                .sortById();
        default:
            return state;
    }
}
