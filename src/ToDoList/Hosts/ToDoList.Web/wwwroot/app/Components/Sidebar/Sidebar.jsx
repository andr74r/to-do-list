import React from 'react';
import PropTypes from 'prop-types';

import '../../Styles/Sidebar/sidebar.css'

export class Sidebar extends React.Component {
    render() {
        return <div className="sidebar">
            <a className="sidebar__category">Category1</a>
            <a className="sidebar__category">Category2</a>
        </div>
    }
}

Sidebar.propTypes = {};