import React from 'react';
import { connect } from 'react-redux';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';

import '../../Styles/Header/header';

class Header extends React.Component {
    componentDidMount() {
    }

    render() {
        return <AppBar position="static" className="header">
            <Toolbar>
                <Typography variant="h6" className="header__title">ToDo List</Typography>
                <Link color="inherit" href="/login">Login</Link>
            </Toolbar>
        </AppBar>;
    }
}

const mapStateToProps = state => {
    return {
    }
}

const mapDispatchToProps = dispatch => {
    return {
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Header)