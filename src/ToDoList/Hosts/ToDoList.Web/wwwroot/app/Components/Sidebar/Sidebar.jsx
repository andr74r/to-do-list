import React from 'react';
import PropTypes from 'prop-types';

import Drawer from '@material-ui/core/Drawer';
import Divider from '@material-ui/core/Divider';

import { CategoryList } from './CategoryList/CategoryList';
import { AddCategoryControl } from './CategoryList/AddCategoryControl';

import './sidebar.css';

export class Sidebar extends React.Component {
    render() {
        return <Drawer
                variant="permanent"
                open
                className="sidebar">
            <CategoryList 
                categories = {this.props.categories}/>
            <Divider />
            <AddCategoryControl 
                createCategory = {this.props.createCategory}/>
        </Drawer>
    }
}

Sidebar.propTypes = {
    categories: PropTypes.array,
    createCategory: PropTypes.func
};