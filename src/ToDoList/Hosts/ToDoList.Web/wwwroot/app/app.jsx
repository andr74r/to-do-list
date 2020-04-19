import React from 'react';
import { render } from 'react-dom'

import { Content } from './Components/Content/Content';
import { Sidebar } from './Components/Sidebar/Sidebar';

class App extends React.Component {
    render() {
        return <div>
            <Sidebar />
            <Content />
        </div>;
    }
}

render(
  <App />,
  document.getElementById("content")
);