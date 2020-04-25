import React from 'react';
import PropTypes from 'prop-types';

import Checkbox from '@material-ui/core/Checkbox';

export class Issue extends React.Component {
    render() {
        const {issue} = this.props;

        return <div>
            <Checkbox
                checked={issue.isCompleted}
                onChange={() => this.props.changeIssueStatus(issue.id)}
                color="primary"
            />
            {issue.name}
        </div>
    }
}

Issue.propTypes = {
    issue: PropTypes.object,
    changeIssueStatus: PropTypes.func
};