import React from 'react';
import { render } from 'react-dom'

import {IssueList} from './Components/IssueList/IssueList';

class App extends React.Component {
    render() {
        const issues = [
            { name: 'issue1', isCompleted: true, id: 1 },
            { name: 'issue2', isCompleted: false, id: 2 }
        ];

        return <IssueList 
            issues={issues}
            changeIssueStatus={(id) => {console.log(id)}} />;
    }
}

render(
  <App />,
  document.getElementById("content")
);