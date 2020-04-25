import React from 'react';
import PropTypes from 'prop-types';

import { IssueTypePicker } from './IssueTypePicker/IssueTypePicker';
import { IssueList } from './IssueList/IssueList';



export class Content extends React.Component {
    render() {
        const { issues } = this.props;

        return <div>
            <IssueTypePicker />
            <IssueList 
                issues = {issues}
                changeIssueStatus = {this.props.changeIssueStatus}/>
        </div>
    }
}

Content.propTypes = {
    issues: PropTypes.array,
    changeIssueStatus: PropTypes.func
};