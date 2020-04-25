import React from 'react';
import PropTypes from 'prop-types';

import List from '@material-ui/core/List';

import {Category} from './Category';

export class CategoryList extends React.Component {
    render() {
        const {categories} = this.props;

        return <List>
            {categories.map(x => 
                <Category 
                    key={x.id}
                    category={x}
                    updateCategory={this.props.updateCategory}
                    deleteCategory={this.props.deleteCategory} />)}
        </List>
    }
}

CategoryList.propTypes = {
    categories: PropTypes.array,
    updateCategory: PropTypes.func,
    deleteCategory: PropTypes.func
};