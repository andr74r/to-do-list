import React, { Component } from 'react';

import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import FormLabel from '@material-ui/core/FormLabel';

import AccountService from '../../../ApiServices/AccountService';

class Login extends Component {
    constructor(props) {
        super(props);

        this.accountService = new AccountService();

        this.state = {
            login: '',
            password: '',
            serverError: ''
        };

        this.onSignInClick = this.onSignInClick.bind(this);
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
                    <Button variant="contained" color="primary" onClick={this.onSignInClick}>Sign In</Button>
                </Grid>
                <Grid item>
                    <Link href="/register">Create new account</Link>
                </Grid>
            </Grid>
        );
    }

    onSignInClick() {
        this.accountService.login(this.state.login, this.state.password)
            .then(response => {
                if (response.data.isLoggedIn)
                {
                    this.goToHomePage();
                }
                else {
                    this.setServerError('Incorrect login or password');
                }
            })
            .catch(error => {
                console.log(error);
            });
    }

    setServerError(error) {
        this.setState({
            serverError: error
        });
    }

    goToHomePage() {
        this.props.history.push('/');
    }
}

export default Login;