import React, { Component } from 'react';

import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Link } from '@material-ui/core';

import AccountService from '../../../ApiServices/AccountService';

class Register extends Component {
    constructor(props){
        super(props);

        this.accountService = new AccountService();

        this.state = {
            email: '',
            phone: '',
            password: '',
            confirmPassword: ''
        };

        this.onSignUpClick = this.onSignUpClick.bind(this);
    }

    render() {
        return (
            <Grid container alignItems="center" direction="column" spacing={3}>
                <Grid item>
                    <h2>Create new account</h2>
                </Grid>
                <Grid item>
                    <TextField 
                        label="Email"
                        value={this.state.email}
                        onChange={e => this.setState({ email: e.target.value })}/>
                </Grid>
                <Grid item>
                    <TextField 
                        label="Phone"
                        value={this.state.phone}
                        onChange={e => this.setState({ phone: e.target.value })}/>
                </Grid>
                <Grid item>
                    <TextField 
                        label="Password" 
                        type="password"
                        value={this.state.password}
                        onChange={e => this.setState({ password: e.target.value })}/>
                </Grid>
                <Grid item>
                    <TextField 
                        label="Confirm Password" 
                        type="password"
                        value={this.state.confirmPassword}
                        onChange={e => this.setState({ confirmPassword: e.target.value })}/>
                </Grid>
                <Grid item>
                    <Button variant="contained" color="primary" onClick={this.onSignUpClick}>Sign Up</Button>
                </Grid>
                <Grid item>
                    <Link href="/login">Sing In</Link>
                </Grid>
            </Grid>
        );
    }

    onSignUpClick() {
        this.accountService.register(this.state.email, this.state.phone, this.state.password)
            .then(response => {
                if (response.data.isLoggedIn)
                {
                    this.props.history.push('/');
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
}

export default Register;