import React, { Component } from 'react';

import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Link } from '@material-ui/core';

class Login extends Component {
    render() {
        return (
            <Grid container alignItems="center" direction="column" spacing={3}>
                <Grid item>
                    <h2>Sign in</h2>
                </Grid>
                <Grid item>
                    <TextField label="Email or phone"/>
                </Grid>
                <Grid item>
                    <TextField label="Password" type="password"/>
                </Grid>
                <Grid item>
                    <Button variant="contained" color="primary">Sign In</Button>
                </Grid>
                <Grid item>
                    <Link href="/register">Create new account</Link>
                </Grid>
            </Grid>
        );
    }
}

export default Login;