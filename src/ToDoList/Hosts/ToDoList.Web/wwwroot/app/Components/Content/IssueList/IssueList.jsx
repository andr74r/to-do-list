import React from 'react';
import PropTypes from 'prop-types';

import {Issue} from './Issue';

export class IssueList extends React.Component {
    render() {
        const {issues} = this.props;

        return <div>
            {issues.map(x => 
                <Issue 
                    key={x.id}
                    issue={x}
                    changeIssueStatus={this.props.changeIssueStatus}
                    deleteIssue={this.props.deleteIssue} />)}
        </div>
    }
}

IssueList.propTypes = {
    issues: PropTypes.array,
    changeIssueStatus: PropTypes.func,
    deleteIssue: PropTypes.func
};