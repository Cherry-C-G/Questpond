import React, { PureComponent } from 'react';
class Parent extends React.Component {
 state = {
 value: ‘Some value’
 };
 
 render() {
 return(
 <Child value={this.state.value} />
 );
 }
}
 
const Child = (props) => (
 <Child2 value={props.value} />
);
 
const Child2 = (props) => (
 <div>{props.value}</div>
);

export default Parent