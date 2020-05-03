import React from 'react';
import { connect } from 'react-redux';

import { loadCategories, createCategory, updateCategory, deleteCategory } from '../../Actions/CategoriesActions/CategoriesActions';
import { changeIssueStatus, createIssue, deleteIssue } from '../../Actions/IssuesActions/IssuesActions';
import { selectCategory } from '../../Actions/SelectedCategoryActions/SelectedCategoryActions';
import { setIssueFilter } from '../../Actions/IssueFilterActions/IssueFilterActions';

import { Content } from './Content/Content';
import { Sidebar } from './Sidebar/Sidebar';

import '../../Styles/HomePage/app';

class HomePage extends React.Component {
    componentDidMount() {
        this.props.loadCategories();
    }

    render() {
        return <div className="home-page">
            <Sidebar
                categories={this.props.categoriesStore}
                createCategory={this.props.createCategory}
                updateCategory={this.props.updateCategory}
                deleteCategory={this.props.deleteCategory}
                selectCategory={this.props.selectCategory} />
            <Content 
                issues={this.props.issuesStore}
                changeIssueStatus={this.props.changeIssueStatus}
                createIssue={this.props.createIssue}
                deleteIssue={this.props.deleteIssue}
                selectedCategoryId={this.props.selectedCategoryId}
                setIssueFilter={this.props.setIssueFilter}
                issueFilter={this.props.issueFilter} />
        </div>;
    }
}

const mapStateToProps = state => {
    return {
        categoriesStore: state.categoriesStore,
        issuesStore: state.issuesStore,
        selectedCategoryId: state.selectedCategoryStore,
        issueFilter: state.issueFilterStore
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
        selectCategory: (categoryId) => {
            dispatch(selectCategory(categoryId));
        },
        setIssueFilter: (filter) => {
            dispatch(setIssueFilter(filter));
        }
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(HomePage)