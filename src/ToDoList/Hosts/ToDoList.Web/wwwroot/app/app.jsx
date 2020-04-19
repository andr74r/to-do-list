import React from 'react';
import { render } from 'react-dom'

import { Content } from './Components/Content/Content';
import { Sidebar } from './Components/Sidebar/Sidebar';

class App extends React.Component {
    render() {
        const issues = [
            { name: 'clean up room', isCompleted: true, id: 1, categoryId: 1 },
            { name: 'fix power socket', isCompleted: false, id: 2, categoryId: 1 }
        ];

        const categories = [
            { name: 'home', userId: 1, id: 1},
            { name: 'work', userId: 2, id: 2}
        ];

        return <div>
            <Sidebar categories = {categories}/>
            <Content issues = {issues}/>
        </div>;
    }
}

render(
  <App />,
  document.getElementById("content")
);