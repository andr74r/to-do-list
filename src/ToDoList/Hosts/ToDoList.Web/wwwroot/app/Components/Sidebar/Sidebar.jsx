import React from 'react';
import PropTypes from 'prop-types';

import { CategoryList } from './CategoryList/CategoryList';
import '../../Styles/Sidebar/sidebar.css'

export class Sidebar extends React.Component {
    render() {
        const {categories} = this.props;

        return <div className="sidebar">
            <CategoryList 
                categories = {categories}/>
        </div>
    }
}

Sidebar.propTypes = {
    categories: PropTypes.array
};