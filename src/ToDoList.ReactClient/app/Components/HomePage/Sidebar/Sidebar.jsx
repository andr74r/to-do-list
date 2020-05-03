import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import Divider from '@material-ui/core/Divider';

import { CategoryList } from './CategoryList/CategoryList';
import { AddCategoryControl } from './CategoryList/AddCategoryControl';

import '../../../Styles/HomePage/sidebar';

export class Sidebar extends React.Component {
    render() {
        return <Fragment>
            <CategoryList 
                categories = {this.props.categories}
                updateCategory={this.props.updateCategory}
                deleteCategory={this.props.deleteCategory}
                selectCategory={this.props.selectCategory} />
            <Divider />
            <AddCategoryControl 
                createCategory = {this.props.createCategory}/>
        </Fragment>;
    }
}

Sidebar.propTypes = {
    categories: PropTypes.array,
    createCategory: PropTypes.func,
    updateCategory: PropTypes.func,
    deleteCategory: PropTypes.func,
    selectCategory: PropTypes.func
};