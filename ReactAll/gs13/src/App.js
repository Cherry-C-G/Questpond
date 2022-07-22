import React, { Component } from 'react';

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
            <ChildContent dataProp = {this.state.data} 
               updateStateProp = {this.updateState}></ChildContent>
         </div>
      );
   }
}
class ChildContent extends React.Component {
   render() {
      return (
         <div>
            <input type = "text" value = {this.props.dataProp} 
               onChange = {this.props.updateStateProp} />
            <h3>{this.props.dataProp}</h3>
         </div>
      );
   }
}
export default App;