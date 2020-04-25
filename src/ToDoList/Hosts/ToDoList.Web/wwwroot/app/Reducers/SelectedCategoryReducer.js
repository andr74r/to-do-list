import { SELECT_CATEGORY } from '../Actions/SelectedCategoryActions/SelectedCategoryActionsType';

export const selectedCategoryReducer = (state = null, action) => {
    switch(action.type) {
        case SELECT_CATEGORY:
            return action.categoryId;
        default:
            return state;
    }
}