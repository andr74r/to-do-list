import React from 'react';
import PropTypes from 'prop-types';

import Checkbox from '@material-ui/core/Checkbox';
import IconButton from '@material-ui/core/IconButton';
import DeleteForeverIcon from '@material-ui/icons/DeleteForever';

export class Issue extends React.Component {
    render() {
        const {issue} = this.props;

        return <div>
            <Checkbox
                checked={issue.isCompleted}
                onChange={() => this.props.changeIssueStatus(this.props.selectedCategoryId, issue.name)}
                color="primary"
            />
            {issue.name}
            <IconButton onClick={() => this.props.deleteIssue(this.props.selectedCategoryId, issue.name)}>
                <DeleteForeverIcon fontSize="small" />
            </IconButton>
        </div>
    }
}

Issue.propTypes = {
    issue: PropTypes.object,
    selectedCategoryId: PropTypes.number,
    changeIssueStatus: PropTypes.func,
    deleteIssue: PropTypes.func
};