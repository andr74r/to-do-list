import React from 'react';
import PropTypes from 'prop-types';

import '../../../Styles/Sidebar/sidebar';

export class Category extends React.Component {
    render() {
        const {category} = this.props;

        return <a className="sidebar__category">{category.name}</a>
    }
}

Category.propTypes = {
    category: PropTypes.object
};