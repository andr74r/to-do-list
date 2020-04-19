import React from 'react';
import PropTypes from 'prop-types';

import { IssueTypePicker } from './IssueTypePicker/IssueTypePicker';

import '../../Styles/Content/content.css';

export class Content extends React.Component {
    render() {
        return <div className="content">
            <IssueTypePicker />
            <p>Issue1</p>
            <p>Issue2</p>
        </div>
    }
}

Content.propTypes = {};