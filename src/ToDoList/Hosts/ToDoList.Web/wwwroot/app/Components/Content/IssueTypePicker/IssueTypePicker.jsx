import React from 'react';
import PropTypes from 'prop-types';

export class IssueTypePicker extends React.Component {
    render() {
        return <div>
            <button className="content__issuetypepicker__choice">Tasks</button>
            <button className="content__issuetypepicker__choice">ToDo</button>
            <button className="content__issuetypepicker__choice">Completed</button>
        </div>
    }
}

IssueTypePicker.propTypes = {};