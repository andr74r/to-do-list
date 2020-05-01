import React, { Component } from 'react';

import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Link } from '@material-ui/core';

class Register extends Component {
    render() {
        return (
            <Grid container alignItems="center" direction="column" xs={24} spacing={3}>
                <Grid item>
                    <h2>Create new account</h2>
                </Grid>
                <Grid item>
                    <TextField label="Email"/>
                </Grid>
                <Grid item>
                    <TextField label="Login"/>
                </Grid>
                <Grid item>
                    <TextField label="Password" type="password"/>
                </Grid>
                <Grid item>
                    <TextField label="Confirm Password" type="password"/>
                </Grid>
                <Grid item>
                    <Button variant="contained" color="primary">Sign Up</Button>
                </Grid>
                <Grid item>
                    <Link href="/Login">Sing In</Link>
                </Grid>
            </Grid>
        );
    }
}

export default Register;