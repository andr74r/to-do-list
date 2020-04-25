import React from 'react';
import PropTypes from 'prop-types';

import AddIcon from '@material-ui/icons/Add';
import CancelIcon from '@material-ui/icons/Cancel';
import TextField from '@material-ui/core/TextField';
import { IconButton } from '@material-ui/core';

import '../../../Styles/sidebar.css';

export class AddCategoryControl extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            categoryName: '',
            isTyping: false
        };

        this.onCreateCategoryClick = this.onCreateCategoryClick.bind(this);
        this.onAddCategoryClick = this.onAddCategoryClick.bind(this);
        this.onCancelClick = this.onCancelClick.bind(this);
        this.onCategoryNameChange = this.onCategoryNameChange.bind(this);
    }

    render() {
        return <div>           
            {
                this.state.isTyping
                    ? <div>
                        <IconButton onClick={this.onAddCategoryClick}>
                            <AddIcon />
                        </IconButton>
                        <TextField onChange={this.onCategoryNameChange}/>
                        <IconButton onClick={this.onCancelClick}>
                            <CancelIcon />
                        </IconButton>
                    </div>
                    : <div className="sidebar__create-category-label">
                        <IconButton onClick={this.onCreateCategoryClick}>
                            <AddIcon />
                        </IconButton>
                        Create New Category
                    </div>
            }
        </div>
    }

    onCreateCategoryClick() {
        this.setState({ isTyping: true });
    }

    onAddCategoryClick() {
        this.props.createCategory(this.state.categoryName);

        this.setState({ isTyping: false, categoryName: '' });
    }

    onCancelClick() {
        this.setState({ isTyping: false, categoryName: '' });
    }

    onCategoryNameChange(e) {
        this.setState({ categoryName: e.target.value });
    }
}

AddCategoryControl.propTypes = {
    createCategory: PropTypes.func
};