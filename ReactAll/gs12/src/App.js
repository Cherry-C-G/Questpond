import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
class App extends React.Component {
   constructor(props) {
      super(props);
      
      this.state = {
         data: '...'
      }
      this.updateState = this.updateState.bind(this);
   };
   updateState(e) {
      this.setState({data: e.target.value});
   }
   render() {
      return (
         <div>
            <input type = "text" value = {this.state.data} 
               onChange = {this.updateState} />
            <h4>{this.state.data}</h4>
         </div>
      );
   }
}
export default App;