import React, { Component } from 'react';
import { Router, Route, Link, IndexRoute } from 'react-router'

class App extends React.Component {
   render() {
    const data =[{"name":"test1"},{"name":"test2"}];
	const listItems = data.map((d) => <li key={d.name}>{d.name}</li>);
    return (
      <div>
      {data.map(function(d, idx){
         return (<li key={idx}>{d.name}</li>)
       })}
      </div>
	  <br/>
	   <div>
      {listItems }
      </div>
    );
  }
}


export default App;