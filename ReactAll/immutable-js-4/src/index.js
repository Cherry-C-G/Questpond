import React from "react";
import ReactDOM from "react-dom";
import { Provider, connect } from "react-redux";

import { store, getData, setData } from "./module";
import "./styles.css";

class Parent extends React.Component {
  render() {
    return (
      <div>
        Parent
        <ChildContainer name="One" isAsync />
        <ChildContainer name="Two" />
      </div>
    );
  }
}

class Child extends React.Component {
  changeData = () => {
    if (this.props.isAsync) {
      window.setTimeout(() => {
        this.props.setData(this.props.name);
      }, 1500);
    } else {
      this.props.setData(this.props.name);
    }
  };
  render() {
    return (
      <div>
        <p>Child {this.props.name}!</p>
        <p>{this.props.data}</p>
        <button onClick={this.changeData}>Change</button>
      </div>
    );
  }
}

const mapStateToProps = state => ({ data: getData(state) });
const ChildContainer = connect(mapStateToProps, { setData })(Child);

const rootElement = document.getElementById("root");
ReactDOM.render(
  <Provider store={store}>
    <Parent />
  </Provider>,
  rootElement
);