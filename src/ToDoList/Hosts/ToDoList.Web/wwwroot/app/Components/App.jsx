import React from 'react';
import { connect } from 'react-redux';

import { loadCategories } from '../Actions/CategoriesActions/CategoriesActions';

import { Content } from './Content/Content';
import { Sidebar } from './Sidebar/Sidebar';

class App extends React.Component {
    componentDidMount() {
        this.props.loadCategories();
    }

    render() {
        const issues = [
            { name: 'clean up room', isCompleted: true, id: 1, categoryId: 1 },
            { name: 'fix power socket', isCompleted: false, id: 2, categoryId: 1 }
        ];

        return <div>
            <Sidebar categories = {this.props.categoriesStore}/>
            <Content issues = {issues}/>
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
        }
    }
}

export const Root = connect(
    mapStateToProps,
    mapDispatchToProps
)(App)