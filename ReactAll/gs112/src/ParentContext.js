import React, { PureComponent } from 'react';
const Context = React.createContext();
class XParent extends React.Component {
	state = { x: 1 };
	handleContextChange = x => this.setState({ x });
		render() {
		const contextValue = {
		data: this.state,
		handleChange: this.handleContextChange
		};
		return (
		<Context.Provider value={contextValue}>
		<XChild/>
		</Context.Provider>
		);
		}
}
const XChild = props => <div><XGrandChild/></div>;
const XGrandChild = props => (
	<Context.Consumer>
	{({ handleChange, data }) => (
	<div>
	<button onClick={() => handleChange(2)}>Change</button>
	<XChild2 text={data.x} />
	</div>
	)}
  </Context.Consumer>
);
const XChild2 = props => <p>{props.text}</p>