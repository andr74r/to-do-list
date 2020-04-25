import React from 'react';
import PropTypes from 'prop-types';

import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';

export class IssueTypePicker extends React.Component {
    render() {
        return <div>
            <Grid container spacing={3}>
                <Grid item xs={12} sm={4}>
                    <Button variant="contained" color="primary">
                        Tasks
                    </Button>
                </Grid>
                <Grid item xs={12} sm={4}>
                    <Button variant="contained" color="primary">
                        ToDo
                    </Button>
                </Grid>
                <Grid item xs={12} sm={4}>
                    <Button variant="contained" color="primary">
                        Completed
                    </Button>
                </Grid>
            </Grid>
        </div>
    }
}

IssueTypePicker.propTypes = {};