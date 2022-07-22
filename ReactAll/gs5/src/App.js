import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';


class App extends React.Component {
   constructor() {
      super();
      this.state = {
         data: 
         [
            {
               "id":1,
               "name":"John",
               "rollNo":"20"
            },
            {
               "id":2,
               "name":"Jack",
               "rollNo":"30"
            },
            {
               "id":3,
               "name":"James",
               "rollNo":"40"
            }
         ]
      }
   }
   render() {
      return (
         <div>
            <Header/>
             <table border={1}>
               <tbody>
                  {this.state.data.map((student, i) => <StudentTableRow key = {i} 
                     data = {student} />)}
               </tbody>
            </table>
         </div>
      );
   }
}
class Header extends React.Component {
   render() {
      return (
         <div>
            <h1>Student table</h1>
         </div>
      );
   }
}
class StudentTableRow extends React.Component {
   render() {
      return (
         <tr>
            <td>{this.props.data.id}</td>
            <td>{this.props.data.name}</td>
            <td>{this.props.data.rollNo}</td>
         </tr>
      );
   }
}
export default App;