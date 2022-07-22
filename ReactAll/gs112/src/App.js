import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Welcome from './Welcome'
import Hello from './Hello'

class App extends Component {
	constructor() {
      super();
      this.forceUpdateHandler = this.forceUpdateHandler.bind(this);
   };
   forceUpdateHandler() {
      this.forceUpdate();
   };
  render() {
    return (
      <div className="App">
       <Welcome></Welcome>
	   <Hello></Hello>
	   <button onClick = {this.forceUpdateHandler}>FORCE UPDATE</button>
      </div>
    );
  }
}

export default App;
