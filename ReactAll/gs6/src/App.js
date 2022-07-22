import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';


class App extends React.Component {
   constructor() {
      super();
   }
     
   render() {
      return (
         <div>
            <MessageComponent message="Hello" nextMessage="after 15 days next message"/>
           
         </div>
      );
   }
}
class MessageComponent  extends React.Component {
   render() {
      return (
        <div>
             <div>{this.props.message}</div>
			 <div>{this.props.nextMessage}</div>
			 </div>
       
      );
   }
}

export default App;