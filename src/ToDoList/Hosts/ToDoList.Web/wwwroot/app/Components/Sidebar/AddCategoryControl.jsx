import React from 'react';
import PropTypes from 'prop-types';

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
                        <input type="text" value={this.state.categoryName} onChange={this.onCategoryNameChange} />
                        <button onClick={this.onAddCategoryClick}>Add</button>
                        <button onClick={this.onCancelClick}>Cancel</button>
                    </div>
                    : <button onClick={this.onCreateCategoryClick}>Create Category</button>
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