import React from 'react';
import PropTypes from 'prop-types';

import { IssueTypePicker } from './IssueTypePicker/IssueTypePicker';
import { IssueList } from './IssueList/IssueList';

import '../../Styles/Content/content.css';

export class Content extends React.Component {
    render() {
        const { issues } = this.props;

        return <div className="content">
            <IssueTypePicker />
            <IssueList 
                issues = {issues}/>
        </div>
    }
}

Content.propTypes = {
    issues: PropTypes.array
};