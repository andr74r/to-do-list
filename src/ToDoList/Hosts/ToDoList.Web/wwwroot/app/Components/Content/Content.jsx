import React from 'react';
import PropTypes from 'prop-types';

import '../../Styles/Content/content.css';

export class Content extends React.Component {
    render() {
        return <div className="content">
            <p>Issue1</p>
            <p>Issue2</p>
        </div>
    }
}

Content.propTypes = {};