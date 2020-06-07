import React from 'react';
import { connect } from 'react-redux';

import Grid from '@material-ui/core/Grid';

import { loadCategories, createCategory, updateCategory, deleteCategory } from '../../Actions/CategoriesActions/CategoriesActions';
import { changeIssueStatus, createIssue, deleteIssue } from '../../Actions/IssuesActions/IssuesActions';
import { selectCategory } from '../../Actions/SelectedCategoryActions/SelectedCategoryActions';
import { setIssueFilter } from '../../Actions/IssueFilterActions/IssueFilterActions';

import { Content } from './Content/Content';
import { Sidebar } from './Sidebar/Sidebar';

class HomePage extends React.Component {
    componentDidMount() {
        this.props.loadCategories();
    }

    render() {
        return <Grid container spacing={3}>
            <Grid item xs={3}>
                <Sidebar
                    categories={this.props.categoriesStore}
                    createCategory={this.props.createCategory}
                    updateCategory={this.props.updateCategory}
                    deleteCategory={this.props.deleteCategory}
                    selectCategory={this.props.selectCategory} />
            </Grid>
            <Grid item xs={9}>
                <Content 
                    issues={this.props.issuesStore}
                    changeIssueStatus={this.props.changeIssueStatus}
                    createIssue={this.props.createIssue}
                    deleteIssue={this.props.deleteIssue}
                    selectedCategoryId={this.props.selectedCategoryId}
                    setIssueFilter={this.props.setIssueFilter}
                    issueFilter={this.props.issueFilter} />
            </Grid>
        </Grid>;
    }
}

const mapStateToProps = state => {
    return {
        categoriesStore: state.categoriesStore,
        issuesStore: state.issuesStore,
        selectedCategoryId: state.selectedCategoryStore.id,
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
        changeIssueStatus: (categoryId, issueName) => {
            dispatch(changeIssueStatus(categoryId, issueName));
        },
        createIssue: (categoryId, name) => {
            dispatch(createIssue(categoryId, name));
        },
        deleteIssue: (categoryId, issueName) => {
            dispatch(deleteIssue(categoryId, issueName));
        },
        selectCategory: (category) => {
            dispatch(selectCategory(category));
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