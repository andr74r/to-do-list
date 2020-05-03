import React from 'react';
import PropTypes from 'prop-types';

import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';

import FilterType from '../../../../Consts/FilterType';

export class IssueTypePicker extends React.Component {
    render() {
        return <div>
            <Grid container spacing={5}>
                <Grid item>
                    <Button variant="contained" color="primary" onClick={() => this.props.setIssueFilter(FilterType.all)}>
                        Tasks
                    </Button>
                </Grid>
                <Grid item>
                    <Button variant="contained" color="primary" onClick={() => this.props.setIssueFilter(FilterType.todo)}>
                        ToDo
                    </Button>
                </Grid>
                <Grid item>
                    <Button variant="contained" color="primary" onClick={() => this.props.setIssueFilter(FilterType.completed)}>
                        Completed
                    </Button>
                </Grid>
            </Grid>
        </div>
    }
}

IssueTypePicker.propTypes = {
    setIssueFilter: PropTypes.func
};