import React from 'react';

import './App.css';
import ApolloClient from "apollo-boost";
import { ApolloProvider } from "react-apollo";
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import Courses from './Courses';

const client = new ApolloClient({
  uri: "https://vm8mjvrnv3.lp.gql.zone/graphql"
});
const App = () => (
  <ApolloProvider client={client}>
    <div className="container">
      <nav className="navbar navbar-dark bg-primary">
        <a className="navbar-brand" href="#">React and GraphQL - Sample Application</a>
      </nav>
      <div>
        <Courses />
      </div>
    </div>
  </ApolloProvider>
);
export default App;
