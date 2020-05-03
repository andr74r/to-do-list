import React from 'react';
import { connect } from 'react-redux';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import Button from '@material-ui/core/Button';

import { loadUser, signOut } from '../../Actions/UserActions/UserActions';

import '../../Styles/Header/header';

class Header extends React.Component {
    componentDidMount() {
        this.props.loadUser();
    }

    render() {
        return <AppBar position="static" className="header">
            <Toolbar>
                <Typography variant="h6" className="header__title">ToDo List</Typography>
                {this.renderUser()}
            </Toolbar>
        </AppBar>;
    }

    renderUser() {
        const { user } = this.props;

        if (!user) {
            return null;
        }

        return !user.isLoggedIn
            ? <Button color="inherit" onClick={() => this.toLoginPage()}>Login</Button>
            : <Button color="inherit" onClick={() => this.signOut()}>Sign out</Button>
    }

    signOut() {
        this.props.signOut(() => this.toLoginPage());
    }

    toLoginPage() {
        window.location.href = '/login';
    }
}

const mapStateToProps = state => {
    return {
        user: state.userStore
    }
}

const mapDispatchToProps = dispatch => {
    return {
        loadUser: () => {
            dispatch(loadUser());
        },
        signOut: (callback) => {
            dispatch(signOut(callback));
        }
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Header)