import React, { Component } from 'react'
import { Table,Tr,Td } from 'reactable'


class App extends Component {
   render() {
      
      
      return (
         <div>
            <Table className="table" id="table">
        <Tr>
            <Td column="Name" data="Griffin Smith">
                <b>Griffin Smith</b>
            </Td>
            <Td column="Age">18</Td>
        </Tr>
        <Tr>
            <Td column="Name">Lee Salminen</Td>
            <Td column="Age">23</Td>
        </Tr>
        <Tr>
            <Td column="Position">Developer</Td>
            <Td column="Age">28</Td>
        </Tr>
    </Table>
         </div>
      )
   }
}

export default App;