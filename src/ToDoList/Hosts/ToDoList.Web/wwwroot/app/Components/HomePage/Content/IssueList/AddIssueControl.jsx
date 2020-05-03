import React from 'react';
import PropTypes from 'prop-types';

import AddIcon from '@material-ui/icons/Add';
import DoneIcon from '@material-ui/icons/Done';
import CancelIcon from '@material-ui/icons/Cancel';
import TextField from '@material-ui/core/TextField';
import { IconButton } from '@material-ui/core';

export class AddIssueControl extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            name: '',
            isTyping: false
        };

        this.onCreateClick = this.onCreateClick.bind(this);
        this.onSubmitClick = this.onSubmitClick.bind(this);
        this.onCancelClick = this.onCancelClick.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
    }

    render() {

        if (!this.props.selectedCategoryId) {
            return null;
        }

        return <div>
            {
                this.state.isTyping
                    ? <div>
                        <TextField onChange={this.onNameChange}/>
                        <IconButton onClick={this.onSubmitClick}>
                            <DoneIcon />
                        </IconButton>
                        <IconButton onClick={this.onCancelClick}>
                            <CancelIcon />
                        </IconButton>
                    </div>
                    : <div>
                        Create New Issue
                        <IconButton onClick={this.onCreateClick}>
                            <AddIcon />
                        </IconButton>
                    </div>
            }
        </div>
    }

    onCreateClick() {
        this.setState({ isTyping: true });
    }

    onSubmitClick() {
        this.props.createIssue(this.props.selectedCategoryId, this.state.name);

        this.setState({ isTyping: false, name: '' });
    }

    onCancelClick() {
        this.setState({ isTyping: false, name: '' });
    }

    onNameChange(e) {
        this.setState({ name: e.target.value });
    }
}

AddIssueControl.propTypes = {
    createCategory: PropTypes.func,
    createIssue: PropTypes.func
};