import React from 'react';
import PropTypes from 'prop-types';

import {Issue} from './Issue';

import FilterType from '../../../../Consts/FilterType';

export class IssueList extends React.Component {
    render() {
        const { issues, issueFilter } = this.props;

        let filteredIssue = [];

        switch (issueFilter)
        {
            case FilterType.completed:
                filteredIssue = issues.filter(x => x.isCompleted);
                break;
            case FilterType.todo:
                filteredIssue = issues.filter(x => !x.isCompleted);
                break;
            case FilterType.all:
            default:
                filteredIssue = issues;
                break;
        }

        return <div>
            {filteredIssue.map(x => 
                <Issue 
                    key={x.id}
                    issue={x}
                    selectedCategoryId={this.props.selectedCategoryId}
                    changeIssueStatus={this.props.changeIssueStatus}
                    deleteIssue={this.props.deleteIssue} />)}
        </div>
    }
}

IssueList.propTypes = {
    issues: PropTypes.array,
    selectedCategoryId: PropTypes.number,
    changeIssueStatus: PropTypes.func,
    deleteIssue: PropTypes.func,
    issueFilter: PropTypes.string
};