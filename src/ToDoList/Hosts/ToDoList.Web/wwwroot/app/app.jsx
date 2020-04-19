import React from 'react';
import { render } from 'react-dom'

class ToDoList extends React.Component {
    render() {
        return <h1>ToDoList</h1>;
    }
}

render(
  <ToDoList />,
  document.getElementById("content")
);