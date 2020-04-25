import React from 'react';
import { connect } from 'react-redux';

import { loadCategories, createCategory, updateCategory, deleteCategory } from '../Actions/CategoriesActions/CategoriesActions';

import { Content } from './Content/Content';
import { Sidebar } from './Sidebar/Sidebar';

import './app.css';

class App extends React.Component {
    componentDidMount() {
        this.props.loadCategories();
    }

    render() {
         const issues = [
            { name: 'clean up room', isCompleted: true, id: 1, categoryId: 1 },
            { name: 'fix power socket', isCompleted: false, id: 2, categoryId: 1 }
        ];

        return <div className="root">
            <Sidebar
                categories={this.props.categoriesStore}
                createCategory={this.props.createCategory}
                updateCategory={this.props.updateCategory}
                deleteCategory={this.props.deleteCategory} />
            <Content 
                issues={issues}
                changeIssueStatus={this.props.changeIssueStatus} />
        </div>;
    }
}

const mapStateToProps = state => {
    return {
        categoriesStore: state.categoriesStore
    }
}

const mapDispatchToProps = dispatch => {
    return {
        loadCategories: () => {
            dispatch(loadCategories());
        },
        createCategory: (name) => {
            dispatch(createCategory(name));
        },
        updateCategory: (category) => {
            dispatch(updateCategory(category));
        },
        deleteCategory: (id) => {
            dispatch(deleteCategory(id));
        },
        changeIssueStatus: (id) => {
            console.log(id);
        }
    }
}

export const Root = connect(
    mapStateToProps,
    mapDispatchToProps
)(App)