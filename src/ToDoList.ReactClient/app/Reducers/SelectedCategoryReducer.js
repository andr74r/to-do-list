import { SELECT_CATEGORY } from '../Actions/SelectedCategoryActions/SelectedCategoryActionsType';

export const selectedCategoryReducer = (state = {}, action) => {
    switch(action.type) {
        case SELECT_CATEGORY:
            return action.category;
        default:
            return state;
    }
}