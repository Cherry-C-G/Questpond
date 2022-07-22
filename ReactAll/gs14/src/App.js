import React, { Component } from 'react';
class App extends React.Component {
   constructor(props) {
      super(props);
      
      this.state = {
         data: '..'
      }
      this.updateState = this.updateState.bind(this);
   };
   updateState() {
      this.setState({data: 'Data updated...'})
   }
   render() {
      return (
         <div>
            <button onClick = {this.updateState}>Button click event</button>
            <h4>{this.state.data}</h4>
         </div>
      );
   }
}
export default App;