import React from 'react';
import PropTypes from 'prop-types';

export class Issue extends React.Component {
    render() {
        const {issue} = this.props;

        return <div>
            <input 
                type="checkbox"
                checked={issue.isCompleted}
                onChange={() => this.props.changeIssueStatus(issue.id)} />
            {issue.name}
        </div>
    }
}

Issue.propTypes = {
    issue: PropTypes.object,
    changeIssueStatus: PropTypes.func
};