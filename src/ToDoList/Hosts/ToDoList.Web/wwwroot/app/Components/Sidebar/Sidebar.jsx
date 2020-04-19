import React from 'react';
import PropTypes from 'prop-types';

import '../../Styles/Sidebar/sidebar.css'

export class Sidebar extends React.Component {
    render() {
        return <div className="sidebar">
            <p>Category1</p>
            <p>Category2</p>
        </div>
    }
}

Sidebar.propTypes = {};