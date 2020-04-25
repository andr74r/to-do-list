import React from 'react';
import { connect } from 'react-redux';

import { loadCategories, createCategory, updateCategory, deleteCategory } from '../Actions/CategoriesActions/CategoriesActions';
import { changeIssueStatus, createIssue, deleteIssue, loadIssues } from '../Actions/IssuesActions/IssuesActions';

import { Content } from './Content/Content';
import { Sidebar } from './Sidebar/Sidebar';

import '../Styles/app.css';

class App extends React.Component {
    componentDidMount() {
        this.props.loadCategories();
    }

    render() {
        return <div className="root">
            <Sidebar
                categories={this.props.categoriesStore}
                createCategory={this.props.createCategory}
                updateCategory={this.props.updateCategory}
                deleteCategory={this.props.deleteCategory} />
            <Content 
                issues={this.props.issuesStore}
                changeIssueStatus={this.props.changeIssueStatus}
                createIssue={this.props.createIssue}
                deleteIssue={this.props.deleteIssue}
                selectedCategoryId={this.props.selectedCategoryId} />
        </div>;
    }
}

const mapStateToProps = state => {
    return {
        categoriesStore: state.categoriesStore,
        issuesStore: state.issuesStore,
        selectedCategoryId: state.selectedCategoryStore
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
        changeIssueStatus: (id, isCompleted) => {
            dispatch(changeIssueStatus(id, isCompleted));
        },
        createIssue: (categoryId, name) => {
            dispatch(createIssue(categoryId, name));
        },
        deleteIssue: (id) => {
            dispatch(deleteIssue(id));
        },
        loadIssues: (categoryId) => {
            dispatch(loadIssues(categoryId));
        }
    }
}

export const Root = connect(
    mapStateToProps,
    mapDispatchToProps
)(App)