import React, { PureComponent } from 'react';
class Welcome extends React.PureComponent {  
  render() {
	console.log("Pure component loaded")
    return <h1>Welcome</h1>
  }
}

export default  Welcome