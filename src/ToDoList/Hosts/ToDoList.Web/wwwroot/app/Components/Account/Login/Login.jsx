import React, { Component } from 'react';
import { connect } from 'react-redux';

import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import FormLabel from '@material-ui/core/FormLabel';

import { login } from '../../../Actions/UserActions/UserActions';

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            login: '',
            password: '',
            serverError: ''
        };
    }

    render() {
        return (
            <Grid container alignItems="center" direction="column" spacing={3}>
                <Grid item>
                    <h2>Sign in</h2>
                </Grid>
                <Grid item>
                    <TextField 
                        label="Email or phone" 
                        value={this.state.login} 
                        onChange={e => this.setState({ login: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField 
                        label="Password" 
                        type="password"
                        value={this.state.password}
                        onChange={e => this.setState({ password: e.target.value })}/>
                </Grid>
                {
                    !!this.state.serverError 
                        ? <Grid item>
                            <FormLabel error>{this.state.serverError}</FormLabel>
                        </Grid>
                        : null
                }
                <Grid item>
                    <Button variant="contained" color="primary" onClick={() => this.onSignInClick()}>Sign In</Button>
                </Grid>
                <Grid item>
                    <Link href="/register">Create new account</Link>
                </Grid>
            </Grid>
        );
    }

    onSignInClick() {
        this.props.login(
            this.state.login,
            this.state.password,
            () => this.toHomePage(), 
            () => this.setServerError('Incorrect login or password'));
    }

    setServerError(error) {
        this.setState({
            serverError: error
        });
    }

    toHomePage() {
        this.props.history.push('/');
    }
}

const mapDispatchToProps = dispatch => {
    return {
        login: (name, password, successCallback, failCallback) => {
            dispatch(login(name, password, successCallback, failCallback));
        }
    }
}

export default connect(
    null,
    mapDispatchToProps
)(Login)