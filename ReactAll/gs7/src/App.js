import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends React.Component {
   constructor(props) {
      super(props);
		
      this.state = {
         header: "From custom",
		 currentDate: new Date(),
         content: "Content from state..."
      }
   }
   render() {
      return (
         <div>
            <h1>{this.state.header}</h1>
            <h2>{this.state.content}</h2>
			 <h2>{this.state.currentDate.toLocaleString()}</h2>
         </div>
      );
   }
}
export default App