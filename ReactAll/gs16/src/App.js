import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
class App extends React.Component {
   render() {
   
      constructor() {
		  super();
			
		  this.state = {
			 data:[
				{
				   component: 'Some component 1...',
				   id: 1
				},
				{
				   component: 'Some component 2...',
				   id: 2
				},
				{
				   component: 'Some component 3...',
				   id: 3
				}
			 ]
		  }
   }
		   render() {
			  return (
				 <div>
					<div>
					   {this.state.data.map((dataSet, i) => <CustomContent 
						  key = {i} componentData = {dataSet}/>)}
					</div>
				 </div>
			  );
		   }
}
class CustomContent extends React.Component {
   render() {
      return (
         <div>
            <div>{this.props.componentData.component}</div>
            <div>{this.props.componentData.id}</div>
         </div>
      );
   }
}
export default App;