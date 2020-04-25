import React from 'react';
import PropTypes from 'prop-types';

import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

export class Category extends React.Component {
    render() {
        const {category} = this.props;
        
        return <ListItem button key={category.id}>
            <ListItemText primary={category.name} />
        </ListItem>
    }
}

Category.propTypes = {
    category: PropTypes.object
};