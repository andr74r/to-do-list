import React, { Fragment } from 'react';
import PropTypes from 'prop-types';

import { IssueTypePicker } from './IssueTypePicker/IssueTypePicker';
import { IssueList } from './IssueList/IssueList';
import { AddIssueControl } from './IssueList/AddIssueControl';

export class Content extends React.Component {
    render() {
        const { issues } = this.props;

        return <Fragment>
            <IssueTypePicker 
                setIssueFilter={this.props.setIssueFilter}/>
            <IssueList 
                issues={issues}
                changeIssueStatus={this.props.changeIssueStatus}
                deleteIssue={this.props.deleteIssue}
                issueFilter={this.props.issueFilter}/>
            <AddIssueControl
                createIssue={this.props.createIssue}
                selectedCategoryId={this.props.selectedCategoryId}
            />
        </Fragment>
    }
}

Content.propTypes = {
    issues: PropTypes.array,
    changeIssueStatus: PropTypes.func,
    createIssue: PropTypes.func,
    selectedCategoryId: PropTypes.number,
    deleteIssue: PropTypes.func,
    setIssueFilter: PropTypes.func,
    issueFilter: PropTypes.string
};