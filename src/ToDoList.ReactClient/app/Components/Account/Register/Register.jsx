import React, { Component } from 'react';
import { connect } from 'react-redux';

import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import FormLabel from '@material-ui/core/FormLabel';

import { register } from '../../../Actions/UserActions/UserActions';

class Register extends Component {
    constructor(props){
        super(props);

        this.state = {
            email: '',
            emailError: '',
            phone: '',
            phoneError: '',
            password: '',
            passwordError: '',
            confirmPassword: '',
            confirmPasswordError: '',
            serverError: ''
        };
    }

    render() {
        return (
            <Grid container alignItems="center" direction="column" spacing={3}>
                <Grid item>
                    <h2>Create new account</h2>
                </Grid>
                <Grid item>
                    <TextField
                        error={!!this.state.emailError}
                        helperText={this.state.emailError}
                        label="Email"
                        value={this.state.email}
                        onChange={e => this.setState({ email: e.target.value })}/>
                </Grid>
                <Grid item>
                    <TextField 
                        error={!!this.state.phoneError}
                        helperText={this.state.phoneError}
                        label="Phone"
                        value={this.state.phone}
                        onChange={e => this.setState({ phone: e.target.value })}/>
                </Grid>
                <Grid item>
                    <TextField 
                        error={!!this.state.passwordError}
                        helperText={this.state.passwordError}
                        label="Password" 
                        type="password"
                        value={this.state.password}
                        onChange={e => this.setState({ password: e.target.value })}/>
                </Grid>
                <Grid item>
                    <TextField 
                        error={!!this.state.confirmPasswordError}
                        helperText={this.state.confirmPasswordError}
                        label="Confirm Password" 
                        type="password"
                        value={this.state.confirmPassword}
                        onChange={e => this.setState({ confirmPassword: e.target.value })}/>
                </Grid>
                {
                    !!this.state.serverError 
                        ? <Grid item>
                            <FormLabel error>{this.state.serverError}</FormLabel>
                        </Grid>
                        : null
                }
                <Grid item>
                    <Button variant="contained" color="primary" onClick={() => this.onSignUpClick()}>Sign Up</Button>
                </Grid>
                <Grid item>
                    <Link href="/login">Sing In</Link>
                </Grid>
            </Grid>
        );
    }

    onSignUpClick() {
        this.clearErrors();

        if (this.validate()) {
            this.register();
        }
    }

    validate() {
        let hasErrors = false;

        if (!/\S+@\S+\.\S+/.test(this.state.email)) {
            hasErrors = true;

            this.setState({
                emailError: 'Email is incorrect'
            });
        }

        if (!/^[0-9\-\+]{9,15}$/.test(this.state.phone)) {
            hasErrors = true;

            this.setState({
                phoneError: 'Phone is incorrect'
            });
        }

        if (!this.state.password) {
            hasErrors = true;

            this.setState({
                passwordError: 'Password is incorrect'
            });
        }

        if (this.state.password != this.state.confirmPassword) {
            hasErrors = true;

            this.setState({
                confirmPasswordError: 'Does not match'
            });
        }

        return !hasErrors;
    }

    clearErrors() {
        this.setState({
            emailError: '',
            phoneError: '',
            passwordError: '',
            confirmPasswordError: ''
        });
    }

    register() {
        this.props.register(
            this.state.email, 
            this.state.phone, 
            this.state.password,
            () => this.toHomePage(),
            () => this.setServerError('User already exists'));
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
        register: (email, phone, password, successCallback, failCallback) => {
            dispatch(register(email, phone, password, successCallback, failCallback));
        }
    }
}

export default connect(
    null,
    mapDispatchToProps
)(Register)