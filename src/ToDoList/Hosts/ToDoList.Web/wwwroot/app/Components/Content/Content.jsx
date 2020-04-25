import React from 'react';
import PropTypes from 'prop-types';

import { IssueTypePicker } from './IssueTypePicker/IssueTypePicker';
import { IssueList } from './IssueList/IssueList';
import { AddIssueControl } from './IssueList/AddIssueControl';

export class Content extends React.Component {
    render() {
        const { issues } = this.props;

        return <div>
            <IssueTypePicker />
            <IssueList 
                issues={issues}
                changeIssueStatus={this.props.changeIssueStatus}
                deleteIssue={this.props.deleteIssue}/>
            <AddIssueControl
                createIssue={this.props.createIssue}
                selectedCategoryId={this.props.selectedCategoryId}
            />
        </div>
    }
}

Content.propTypes = {
    issues: PropTypes.array,
    changeIssueStatus: PropTypes.func,
    createIssue: PropTypes.func,
    selectedCategoryId: PropTypes.number,
    deleteIssue: PropTypes.func
};