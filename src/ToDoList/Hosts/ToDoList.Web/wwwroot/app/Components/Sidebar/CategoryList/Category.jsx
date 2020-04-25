import React from 'react';
import PropTypes from 'prop-types';

import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import DeleteForeverIcon from '@material-ui/icons/DeleteForever';
import EditIcon from '@material-ui/icons/Edit';
import { IconButton } from '@material-ui/core';
import TextField from '@material-ui/core/TextField';
import CancelIcon from '@material-ui/icons/Cancel';
import DoneIcon from '@material-ui/icons/Done';

export class Category extends React.Component {
    constructor(props){
        super(props);

        this.state = {
          isEditing: false,
          name: props.category.name
        };

        this.onEditClick = this.onEditClick.bind(this);
        this.onCancelClick = this.onCancelClick.bind(this);
        this.onSubmitClick = this.onSubmitClick.bind(this);
    }
    
    render() {
        const {category} = this.props;
        
        return <div>
            {
                this.state.isEditing
                    ? <ListItem key={category.id}>
                        <TextField onChange={this.onCategoryNameChange} value={this.state.name}/>
                        <IconButton onClick={this.onSubmitClick}>
                            <DoneIcon />
                        </IconButton>
                        <IconButton onClick={this.onCancelClick}>
                            <CancelIcon />
                        </IconButton>
                    </ListItem>
                    : <ListItem button key={category.id} onClick={this.onNameClick}>
                        <ListItemText primary={category.name} />
                        <IconButton onClick={this.onEditClick}>
                            <EditIcon fontSize="small" />
                        </IconButton>
                        <IconButton onClick={this.onDeleteClick}>
                            <DeleteForeverIcon fontSize="small" />
                        </IconButton>
                    </ListItem>
            }
        </div>
    }

    onDeleteClick(e) {
        console.log('delete');
        e.stopPropagation();
    }

    onEditClick(e) {
        this.setState({ isEditing: true });
        e.stopPropagation();
    }

    onCancelClick(e) {
        this.setState({ 
            isEditing: false, 
            name: this.props.category.name 
        });
        e.stopPropagation();
    }

    onSubmitClick(e) {
        console.log('submit');
        this.setState({ 
            isEditing: false, 
            name: this.props.category.name 
        });
        e.stopPropagation();
    }

    onNameClick(e) {
        console.log('name');
        e.stopPropagation();
    }
}

Category.propTypes = {
    category: PropTypes.object
};