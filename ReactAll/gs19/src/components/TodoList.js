import React, { Component } from 'react'
import Todo from './Todo.js'
import PropTypes from 'prop-types';

export default class TodoList extends Component {
   render() {
      return (
         <ul>
            {this.props.todos.map(todo =>
               <Todo
                  key = {todo.id}
                  {...todo}
               />
            )}
         </ul>
      )
   }
}